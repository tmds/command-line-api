namespace System.CommandLine.Tests.ConventionFree
{
    public interface ISupplySuggestionFunc
    {
        Func<string[]> SuggestionFunc { get; }
    }

}
