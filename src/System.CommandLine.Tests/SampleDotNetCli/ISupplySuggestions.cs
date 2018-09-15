namespace System.CommandLine.Tests.SampleDotNetCli
{
    public interface ISupplySuggestionFunc
    {
        Func<string[]> SuggestionFunc { get; }
    }

}
