using System.Collections.Generic;
using System.CommandLine.Builder;
using System.CommandLine.Tests.ConventionFree.Core;
using System.Linq;
using System.Reflection;

namespace System.CommandLine.Tests.ConventionFree
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = ConventionFreeHelpers.MakeCommandBuilder<RootCommand>();
            // Parent command cannot short circuit a subcommand if the subcommand is specified on the
            // command line.  e.g. dotnet --info new "console" will cause the new subcommand to run and not
            // the dotnet rootcommand processing --info.
            CommandLineParser.Invoke<RootCommand>(args);

        }
    }

    public static class ConventionFreeHelpers
    {
        public static CommandBuilder MakeCommandBuilder<T>()
             where T : Core.Command
        {
            var type = typeof(T);
            var siblingTypeLookup = GetSiblingTypeLookup(type);
            var name = type.Name.StripCommandName();
            var builder = new CommandLineBuilder(name);
            builder.FillCommand(type,siblingTypeLookup);

            return builder;
        }

        private static Dictionary<Type, Type> GetSiblingTypeLookup(Type type)
        {
            var siblingTypes = type.Assembly.GetTypes();
            var lookup = new Dictionary<Type, Type>();
            foreach (var siblingType in siblingTypes)
            {
                lookup.Add(siblingType.BaseType, siblingType);
            }
            return lookup;
        }



    }

    public static class ConventionFreeExtensions
    {
        public static void FillCommand(this CommandBuilder commandBuilder,Type type, Dictionary<Type, Type> siblingTypeLookup)
        {
            commandBuilder.AddArgument(type);
            commandBuilder.AddOptions(type);
            commandBuilder.AddSubCommands(type, siblingTypeLookup: siblingTypeLookup);
        }

        public static CommandBuilder AddArgument(this CommandBuilder commandBuilder, Type type)
        {
            var property = type
                            .GetProperties()
                            .Where(x => x.GetCustomAttribute<ArgumentAttribute>(true) != null)
                            .SingleOrDefault();

            var argType = property.PropertyType;
            if (typeof(Core.Argument).IsAssignableFrom(argType))
            {
                return AddArgumentFromWrapper(commandBuilder, argType, type, property);
            }
            return AddArgumentDirectType(commandBuilder, argType, property);
        }

        private static CommandBuilder AddArgumentDirectType(CommandBuilder commandBuilder, Type argType, PropertyInfo property)
        {
            var name = property.Name;
            bool isZeroAllowed = false;
            string help = string.Empty;

            var argAttribute = property.GetCustomAttribute<ArgumentAttribute>(true);
            if (argAttribute != null)
            {
                if (!string.IsNullOrWhiteSpace(argAttribute.Name))
                {
                    name = argAttribute.Name;
                }
                isZeroAllowed = argAttribute.Optional;
                help = argAttribute.Help;
            }

            // @jonsequitur How do we express whether zero arity is allowed for either multiple or single
            var arg2 = commandBuilder.Arguments
                        .WithHelp(name, help)
                        .ParseArgumentsAs(argType);
            return commandBuilder;
        }

        // KAD: This signature has redundancy. Clean up. 
        private static CommandBuilder AddArgumentFromWrapper(CommandBuilder commandBuilder,
                Type wrapperType, Type containingType, PropertyInfo property)
        {
            if (!wrapperType.IsConstructedGenericType
                && typeof(Core.Argument).IsAssignableFrom(wrapperType)
                && (typeof(Core.Command).IsAssignableFrom(containingType)
                    || typeof(Core.Option).IsAssignableFrom(containingType)))
            {
                throw new InvalidOperationException("AddArgumentFromWrapper only callable on an Argument<T> propertyin a Command class");
            }

            var name = property.Name;
            bool isZeroAllowed = false;
            string help = string.Empty;
            var argType = wrapperType
                            .GetGenericArguments()
                            .First();

            var argAttribute = property.GetCustomAttribute<ArgumentAttribute>(true);
            if (argAttribute != null)
            {
                if (!string.IsNullOrWhiteSpace(argAttribute.Name))
                {
                    name = argAttribute.Name;
                }
                isZeroAllowed = argAttribute.Optional;
                help = argAttribute.Help;
            }

            Func<ParseResult, int?, IEnumerable<string>> suggestions =
                           (parseResult, position)
                           => GetSuggestions(parseResult, position, containingType, p => ((Core.Argument)property.GetValue(p)).Suggestions);

            // @jonsequitur How do we express whether zero arity is allowed for either multiple or single
            var arg2 = commandBuilder.Arguments
                        .WithHelp(name, help)
                        .ParseArgumentsAs(argType);
            return commandBuilder;
        }

        private static IEnumerable<string> GetSuggestions(ParseResult parseResult, int? position, Type containingType,
                    string suggestionMethod)
        {
            var instance = Activator.CreateInstance(containingType);
            // Fill with parse result - @MarkMichaelis
            var methodInfo = containingType.GetMethod(suggestionMethod);
            return (IEnumerable<string>)methodInfo.Invoke(instance, null);
        }

        public static CommandBuilder AddOptions(this CommandBuilder builder, Type type)
        {
            var properties = type
                            .GetProperties()
                            .Where(x => x.GetCustomAttribute(typeof(ArgumentAttribute), true) == null);
            throw new NotImplementedException();
        }

        public static CommandBuilder AddSubCommands(this CommandBuilder builder, Type type, Dictionary<Type, Type> siblingTypeLookup)
        {
            throw new NotImplementedException();
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
            return null;
        }
    }
}
