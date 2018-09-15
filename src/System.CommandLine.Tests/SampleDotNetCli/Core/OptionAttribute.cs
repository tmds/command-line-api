namespace System.CommandLine.Tests.SampleDotNetCli.Core
{
    public class OptionAttribute : Attribute
    {
        private readonly bool _optional;
        private readonly string _alias;

        public OptionAttribute(bool Optional = false, string Alias = null)
        {
            _optional = Optional;
            _alias = Alias;
        }
    }
}
