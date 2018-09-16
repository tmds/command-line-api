namespace System.CommandLine.Tests.ObjectDotNetCli
{
    public interface ISupplySuggestionFunc
    {
        Func<string[]> SuggestionFunc { get; }
    }

}
