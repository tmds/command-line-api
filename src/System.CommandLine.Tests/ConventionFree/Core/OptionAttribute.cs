using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree.Core
{
    public class OptionAttribute : Attribute
    {
        public bool ValueOptional { get; }
        public bool OptionRequired { get; }
        public IEnumerable<string> Suggestions { get; }
        public string Help { get; }
        public string[] Aliases { get; }

        public OptionAttribute(string alias = null, string help=null, bool valueOptional = false, bool optionRequired = false, string[] suggestions = null )
            :this(new string[] { alias }, help, valueOptional, optionRequired, suggestions)
        {
        }

        public OptionAttribute(string[] aliases = null, string help = null, bool valueOptional = false, bool optionRequired = false, string[] suggestions = null)
        {
            ValueOptional = valueOptional;
            OptionRequired = optionRequired;
            Aliases = aliases;
            Help = help;
            Suggestions = suggestions;
        }
    }
}
