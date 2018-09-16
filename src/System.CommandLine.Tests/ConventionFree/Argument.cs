
using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree
{
    public class Argument<T>
    {
        public bool Optional { get; private set; }
        public Func<IEnumerable< string>> Suggestions { get; private set; }
        public Func<IEnumerable<string>> Validation { get; private set; }

        public T Value;

        public Argument(bool optional = false, Func<IEnumerable<string>> suggestions = null, Func<IEnumerable<string>> validation = null)
        {
            Optional =    optional;
            Suggestions = suggestions;
            Validation =  validation;
        }

        public static implicit operator T(Argument<T> argument)
        {
            return argument.Value;
        }
    }
}
