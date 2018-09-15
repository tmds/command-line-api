namespace System.CommandLine.Tests.SampleDotNetCli
{
    public class ArgumentAttribute : Attribute
    {
        private readonly bool _optional;

        public ArgumentAttribute(bool Optional = false)
        {
            _optional = Optional;
        }
    }
}
