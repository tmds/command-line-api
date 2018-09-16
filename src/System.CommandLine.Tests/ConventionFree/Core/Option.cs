using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree.Core
{
    public class Option<T>
    {
        public bool Required { get; private set; }
        public Func<IEnumerable<string>> Suggestions { get; private set; }
        public Func<IEnumerable<string>> Validation { get; private set; }
        public IEnumerable<string> Aliases { get; private set; }

        public T Value;

        public Option(bool required = false, IEnumerable<string> aliases = null, Func<IEnumerable<string>> suggestions = null, Func<IEnumerable<string>> validation = null)
        {
            Required = required;
            Suggestions = suggestions;
            Validation = validation;
        }

        public Option(bool required = false, IEnumerable<string> aliases = null, IEnumerable<string> suggestions = null, Func<IEnumerable<string>> validation = null)
        {
            Required = required;
            Suggestions = () => suggestions;
            Validation = validation;
        }
        public static implicit operator T(Option<T> option)
        {
            return option.Value;
        }
    }
}
