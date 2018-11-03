using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree.Core
{
    public class OptionAttribute : Attribute
    {
        public bool ValueOptional { get; }
        public bool OptionRequired { get; }
        public IEnumerable<string> Suggestions { get; }
        public string Name { get; }
        public string Help { get; }
        public string[] Aliases { get; }
        public Type SuggestionProvider { get; }

        public OptionAttribute(string alias = null, string name = null, string help=null, bool valueOptional = false, bool optionRequired = false, string[] suggestions = null, Type suggestionProvider = null)
            :this(new string[] { alias }, name, help, valueOptional, optionRequired, suggestions, suggestionProvider)
        {
        }

        public OptionAttribute(string[] aliases = null, string name = null, string help = null, bool valueOptional = false, bool optionRequired = false, string[] suggestions = null, Type suggestionProvider = null)
        {
            if (!typeof(ISuggestionProvider).IsAssignableFrom(suggestionProvider))
            {
                throw new InvalidOperationException("Suggestion providers must implement ISuggestionProvider");
            }
            ValueOptional = valueOptional;
            OptionRequired = optionRequired;
            Aliases = aliases;
            Name = name;
            Help = help;
            Suggestions = suggestions;
            SuggestionProvider = suggestionProvider;
        }
    }
}
