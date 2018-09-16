
using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree.Core
{
    public class Argument
    {
        protected Argument(bool optional = false, IEnumerable<string> suggestions = null, Func<IEnumerable<string>> validation = null)
        {
            Optional = optional;
            Suggestions = suggestions;
            Validation = validation;
        }
        public bool Optional { get; private set; }
        public IEnumerable<string> Suggestions { get; private set; }
        public Func<IEnumerable<string>> Validation { get; private set; }
    }

    public class Argument<T> : Argument
    {
        public T Value { get; set; }

        public Argument(bool optional = false, IEnumerable<string> suggestions = null, Func<IEnumerable<string>> validation = null)
            : base(optional, suggestions, validation)
        { }

        public static implicit operator T(Argument<T> argument) => argument.Value;
    }
}
