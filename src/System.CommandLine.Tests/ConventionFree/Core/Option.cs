using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree.Core
{
    public class Option
    {
        public Option(bool required = false, IEnumerable<string> aliases = null, IEnumerable<string> suggestions = null, Func<IEnumerable<string>> validation = null)
        {
            Required = required;
            Suggestions = suggestions;
            Validation = validation;
            Aliases = aliases;
        }

        public bool Required { get; private set; }
        public IEnumerable<string> Suggestions { get; private set; }
        public Func<IEnumerable<string>> Validation { get; private set; }
        public IEnumerable<string> Aliases { get; private set; }
    }

    public class Option<T> : Option
    {

        public T Value;

        public Option(bool required = false, IEnumerable<string> aliases = null,
            IEnumerable<string> suggestions = null, Func<IEnumerable<string>> validation = null)
            : base (required, aliases, suggestions, validation)
        {  }

        public Option(bool required = false, string alias = null, 
            IEnumerable<string> suggestions = null, Func<IEnumerable<string>> validation = null)
              : base(required, new string[] { alias }, suggestions, validation)
        { }

        public static implicit operator T(Option<T> option)
        {
            return option.Value;
        }
    }
}
