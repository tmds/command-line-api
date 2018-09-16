namespace System.CommandLine.Tests.ConventionFree
{
    public class ArgumentAttribute : Attribute
    {
        public bool Optional{get;}
        public Type Suggestions{get;}
        public string Help{get;}

        public ArgumentAttribute(string help = null, bool optional = false, Type suggestions = null)
        {
            Optional = optional;
            Suggestions = suggestions;
            Help = help;
        }
    }
}
