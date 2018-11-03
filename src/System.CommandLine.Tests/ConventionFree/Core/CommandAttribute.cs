namespace System.CommandLine.Tests.ConventionFree
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; }
        public string Help { get; }
        public bool   Hide { get; }

        public CommandAttribute(string name = null,string help=null, bool hide=false)
        {
            Name = name;
            Help = help;
            Hide = hide;
        }
    }
}
