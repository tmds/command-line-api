using System.Collections.Generic;

namespace System.CommandLine.Tests.ConventionFree
{
    public interface ISuggestionProvider
    {    }

    public interface ISuggestionProvider<T> : ISuggestionProvider
    {
        IEnumerable<string> ProvideSuggestions(T instance, int? position);
    }
}
