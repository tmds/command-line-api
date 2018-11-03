using System.Collections.Generic;
using System.CommandLine.Builder;
using System.Linq;
using System.Reflection;

namespace System.CommandLine.Tests.ConventionFree
{
    public static class ConventionFreeExtensions
    {

        public static CommandBuilder FillCommand(this CommandBuilder commandBuilder, Type type, Dictionary<Type, List<Type>> siblingTypeLookup)
        {
            commandBuilder.AddArgument(type);
            commandBuilder.AddOptions(type);
            commandBuilder.AddSubCommands(type, siblingTypeLookup: siblingTypeLookup);
            return commandBuilder;
        }

        public static CommandBuilder AddArgument(this CommandBuilder commandBuilder, Type type)
        {
            var property = type
                            .GetProperties()
                            .Where(x => x.GetCustomAttribute<ArgumentAttribute>(true) != null)
                            .SingleOrDefault();
            if (property != null)
            {
                AddArgumentDirectType(commandBuilder, property);
            }
            return commandBuilder;
        }

        private static CommandBuilder AddArgumentDirectType(CommandBuilder commandBuilder, PropertyInfo property)
        {
            var name = property.Name;
            bool isZeroAllowed = false;
            string help = string.Empty;
            var argType = property.PropertyType;
            Type suggestionProvider = null;

            var argAttribute = property.GetCustomAttribute<ArgumentAttribute>(true);
            if (argAttribute != null)
            {
                if (!string.IsNullOrWhiteSpace(argAttribute.Name))
                {
                    name = argAttribute.Name;
                }
                isZeroAllowed = argAttribute.Optional;
                help = argAttribute.Help;
                suggestionProvider = argAttribute.SuggestionProvider;
            }



            // @jonsequitur How do we express whether zero arity is allowed for either multiple or single
            var arg2 = commandBuilder.Arguments
                        .WithHelp(name, help)
                        .AddSuggestionSource(GetSuggestionSource(suggestionProvider))
                        .ParseArgumentsAs(argType)
                        ;
            return commandBuilder;
        }

        private static Suggest GetSuggestionSource(Type suggestionProviderType)
        {
            if (typeof(ISuggestionProvider).IsAssignableFrom(suggestionProviderType)
                && suggestionProviderType.IsConstructedGenericType)
            {
                throw new ArgumentException("Suggestion providers must be of type ISuggestionProvider<T>");
            }

            // The suggestionProviderType is quite likely not generic, although this interface must be
            var suggestionInterface = suggestionProviderType
                                    .GetInterfaces()
                                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISuggestionProvider<>))
                                    .First();
            var dataType = suggestionInterface
                            .GetGenericArguments()
                            .First();

            var openMethodInfo = typeof(ConventionFreeExtensions).GetMethod(nameof(GetSuggestions), BindingFlags.Static | BindingFlags.NonPublic);
            var methodInfo = openMethodInfo.MakeGenericMethod(new Type[] { dataType, suggestionProviderType });
            return (Suggest)methodInfo.Invoke(null, new object[] { });
        }

        private static Suggest GetSuggestions<TData, TSuggestions>()
            where TSuggestions : ISuggestionProvider<TData>
        {
            return (parseResult, position) =>
                {
                    var instance = Activator.CreateInstance<TData>();
                    // Fill with parse result - @MarkMichaelis
                    var suggestionProvider = Activator.CreateInstance<TSuggestions>();
                    return suggestionProvider.ProvideSuggestions(instance, position);
                };
        }

        public static CommandBuilder AddOptions(this CommandBuilder commandBuilder, Type type)
        {
            var properties = type
                            .GetProperties()
                            .Where(x => x.GetCustomAttribute(typeof(ArgumentAttribute), true) == null);
            // KAD: Add opt out
            foreach (var property in properties)
            {

            }
            return commandBuilder;
        }

        public static CommandBuilder AddOption(this CommandBuilder commandBuilder, PropertyInfo property)
        {
            var name = property.Name;
            bool isZeroAllowed = false;
            string help = string.Empty;
            var argType = property.PropertyType;
            Type suggestionProvider = null;

            var optionAttribute = property.GetCustomAttribute<Core.OptionAttribute>(true);
            if (optionAttribute != null)
            {
                if (!string.IsNullOrWhiteSpace(optionAttribute.Name))
                {
                    name = optionAttribute.Name;
                }
                isZeroAllowed = optionAttribute.ValueOptional;
                help = optionAttribute.Help;
                suggestionProvider = optionAttribute.SuggestionProvider;
            }



            // @jonsequitur How do we express whether zero arity is allowed for either multiple or single
            var arg2 = commandBuilder.Arguments
                        .WithHelp(name, help)
                        .AddSuggestionSource(GetSuggestionSource(suggestionProvider))
                        .ParseArgumentsAs(argType)
                        ;
            return commandBuilder;
        }

        public static CommandBuilder AddSubCommands(this CommandBuilder parentBuilder, Type type, Dictionary<Type, List<Type>> siblingTypeLookup)
        {
            if (!siblingTypeLookup.ContainsKey(type))
            {
                return parentBuilder;
            }
            var derivedTypes = siblingTypeLookup[type];
            foreach (var derivedType in derivedTypes)
            {
                var name = derivedType.Name.StripCommandName();
                var childBuilder = MakeAndFillCommand(parentBuilder, derivedType, siblingTypeLookup);
            }
            return parentBuilder;
        }

        private static CommandBuilder MakeAndFillCommand(CommandBuilder parentBuilder, Type type, Dictionary<Type, List<Type>> siblingTypeLookup)
        {
            var name = type.Name.StripCommandName();
            string help = string.Empty;
            bool hide = false;

            var commandAttribute = type.GetCustomAttribute<CommandAttribute>(true);
            if (commandAttribute != null)
            {
                if (!string.IsNullOrWhiteSpace(commandAttribute.Name))
                {
                    name = commandAttribute.Name;
                }
                help = commandAttribute.Help;
                hide = commandAttribute.Hide;
            }
            parentBuilder.AddCommand(name, help);
            var commandBuilder = parentBuilder.Commands[name];
            return commandBuilder.FillCommand(type, siblingTypeLookup);
        }

        public static string StripCommandName(this string name)
            => StripCommandName(name, Array.Empty<string>());

        public static string StripCommandName(this string name, IEnumerable<string> parentNames)
            => StripItemType(name, "Command")
               .StripParents(parentNames);

        public static string StripItemType(this string name, string itemType)
            => name.EndsWith(itemType, StringComparison.Ordinal)
                ? name.Replace(itemType, "")
                : name;

        public static string StripParents(this string name, IEnumerable<string> parentNames)
        {
            // KAD: Implement removing parents
            return name;
        }
    }
}
