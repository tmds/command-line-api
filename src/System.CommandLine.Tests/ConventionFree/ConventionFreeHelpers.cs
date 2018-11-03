using System.Collections.Generic;
using System.CommandLine.Builder;

namespace System.CommandLine.Tests.ConventionFree
{
    public static class ConventionFreeHelpers
    {
        public static CommandBuilder MakeCommandBuilder<T>()
             where T : Core.Command
        {
            var type = typeof(T);
            var siblingTypeLookup = GetSiblingTypeLookup(type);
            var name = type.Name.StripCommandName();
            var builder = MakeAndFillCommand(type, siblingTypeLookup);

            return builder;
        }

        public static CommandBuilder MakeAndFillCommand(Type type, Dictionary<Type, List<Type>> siblingTypeLookup)
        {
            var name = type.Name.StripCommandName();
            var commandBuilder = new CommandLineBuilder(name);
            return commandBuilder.FillCommand(type, siblingTypeLookup);
        }


        private static Dictionary<Type, List<Type>> GetSiblingTypeLookup(Type type)
        {
            var siblingTypes = type.Assembly.GetTypes();
            var lookup = new Dictionary<Type, List<Type>>();
            foreach (var siblingType in siblingTypes)
            {
                if (!siblingType.IsClass)
                {
                    continue;
                }
                if (lookup.ContainsKey(siblingType.BaseType))
                {
                    lookup[siblingType.BaseType].Add(siblingType);

                }
                else
                {
                    var newList = new List<Type>
                    {
                        siblingType
                    };
                    lookup.Add(siblingType.BaseType, newList);
                }
            }
            return lookup;
        }



    }
}
