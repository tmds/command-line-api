namespace System.CommandLine.Tests.SampleDotNetCli.Core
{
    public class OptionAttribute : Attribute
    {
        private readonly string[] _aliases;
        private readonly bool _valueOptional;
        private readonly bool _optionRequired;

        public OptionAttribute()
        {  }

        public OptionAttribute(string Alias = null, bool ValueOptional = false, bool OptionRequired = false)
        {
            _valueOptional = ValueOptional;
            _optionRequired = OptionRequired;
            _aliases = new string[] { Alias };
        }

        /// <param name="Optional"></param>
        /// <param name="Aliases"></param>
        /// <param name="ValueOptional"></param>
        /// <param name="OptionRequired"></param>
        public OptionAttribute(string[] Aliases = null, bool ValueOptional = false, bool OptionRequired = false)
        {
            _valueOptional = ValueOptional;
            _optionRequired = OptionRequired;
            _aliases = Aliases;
        }
    }
}
