namespace System.CommandLine.Tests.ConventionFree
{
    public class ArgumentAttribute : Attribute
    {
        private readonly bool _optional;
        private readonly Type _suggestions;
        private readonly string _help;

        public ArgumentAttribute(string help = null, bool Optional = false, Type Suggestions = null)
        {
            _optional = Optional;
            _suggestions = Suggestions;
            _help = help;
        }
    }
}
