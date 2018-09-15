namespace System.CommandLine.Tests.SampleDotNetCli
{
    public class ArgumentAttribute : Attribute
    {
        private readonly bool _optional;
        private readonly Type _suggestions;

        public ArgumentAttribute(bool Optional = false, Type Suggestions = null)
        {
            _optional = Optional;
            _suggestions = Suggestions;
        }
    }
}
