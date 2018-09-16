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
            var builder = MakeCommandBuilder<RootCommand>();
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
            builder.AddSubCommands(siblingTypeLookup, type);

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

        public CommandBuilder AddArgument(this CommandBuilder commandBuilder, Type type)
        {
            var property = type
                            .GetProperties()
                            .Where(x => x.GetCustomAttribute<ArgumentAttribute>(true) != null)
                            .SingleOrDefault();

            var argType = property.PropertyType;
            return typeof(Argument<>).IsAssignableFrom(argType)
                  ? AddArgumentFromWrapper(commandBuilder, argType, property)
                  : AddArgumentDirectType(commandBuilder, argType, property);
        }

        private CommandBuilder AddArgumentDirectType(CommandBuilder commandBuilder, Type argType, PropertyInfo property)
        {
            var name = property.Name;
            bool isZeroAllowed = false;

            var argAttribute = property.GetCustomAttribute<ArgumentAttribute>(true);
            if (argAttribute != null)
            {
                if (!string.IsNullOrWhiteSpace(argAttribute.Name))
                {
                    name = argAttribute.Name;
                }
                isZeroAllowed = argAttribute.Optional;
            }

            ArgumentArityValidator arity = null;
            var
            if (attribute == null)
            {

            }
            var name = "Fred";
            var arg = commandBuilder.Arguments.ExactlyOne();
            var arg2 = commandBuilder.Arguments
                        .WithHelp(name, "")
                        .ParseArgumentsAs(type, null, arity);
        }

        private CommandBuilder AddArgumentFromWrapper(CommandBuilder commandBuilder, Type argType)
        {
            throw new NotImplementedException();
        }








        public CommandBuilder AddOptions(this CommandBuilder builder, Type type)
        {
            var properties = type
                            .GetProperties()
                            .Where(x => x.GetCustomAttribute(typeof(ArgumentAttribute), true) == null);

        }

        public CommandBuilder AddSubCommands(this CommandBuilder builder, Dictionary<Type, Type> siblingTypeLookup, Type type)
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
