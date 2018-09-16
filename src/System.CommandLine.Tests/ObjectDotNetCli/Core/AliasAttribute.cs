namespace System.CommandLine.Tests.ObjectDotNetCli.Core
{
    internal class AliasAttribute : Attribute
    {
        public string[] Aliases { get; private set; }
        public AliasAttribute(string[] aliases, bool ignorePropertyName = false)
        {
            Aliases = aliases;
        }
        public AliasAttribute(string alias)
        {
            Aliases = new string[] { alias };
        }
    }
}
