using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree.Core
{
    public class OptionAttribute : Attribute
    {
        private readonly string[] _aliases;
        private readonly bool _valueOptional;
        private readonly bool _optionRequired;
        private readonly IEnumerable<string> _suggestions;
        private readonly string _help;

        public OptionAttribute()
        {  }

        public OptionAttribute(string alias = null, string help=null, bool valueOptional = false, bool optionRequired = false, string[] suggestions = null )
        {
            _valueOptional = valueOptional;
            _optionRequired = optionRequired;
            _aliases = new string[] { alias };
            _suggestions = suggestions;
            _help = help;
        }

        /// <param name="Optional"></param>
        /// <param name="Aliases"></param>
        /// <param name="ValueOptional"></param>
        /// <param name="OptionRequired"></param>
        public OptionAttribute(string[] Aliases = null, string help = null, bool ValueOptional = false, bool OptionRequired = false)
        {
            _valueOptional = ValueOptional;
            _optionRequired = OptionRequired;
            _aliases = Aliases;
            _help = help;
        }
    }
}
