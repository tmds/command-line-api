namespace System.CommandLine.Tests.ConventionFree
{
    public class ArgumentAttribute : Attribute
    {
        public bool Optional{get;}
        public string Help { get; }
        public string Name { get; }
        public Type SuggestionProvider { get; }

        public ArgumentAttribute(string help = null, bool optional = false,  string name = null, Type suggestionProvider = null)
        {
            if (!typeof(ISuggestionProvider).IsAssignableFrom(suggestionProvider ))
            {
                throw new InvalidOperationException("Suggestion providers must implement ISuggestionProvider");
            }
            Optional = optional;
            Help = help;
            Name = name;
            SuggestionProvider = suggestionProvider;
        }
    }
}
