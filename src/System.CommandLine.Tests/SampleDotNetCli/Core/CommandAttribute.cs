namespace System.CommandLine.Tests.SampleDotNetCli
{
    public class CommandAttribute : Attribute
    {
        private readonly string _name;
        private readonly bool _hide;

        public CommandAttribute(string Name = null, bool Hide=false)
        {
            _name = Name;
            _hide = Hide;
        }
    }
}
