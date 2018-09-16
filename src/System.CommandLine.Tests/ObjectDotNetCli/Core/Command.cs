using System.Threading.Tasks;

namespace System.CommandLine.Tests.ObjectDotNetCli.Core
{
    // LATER: Place interface in a separate file
    public interface ICommand
    {
        string[] Aliases { get; set; }

        Task<int> InvokeAsync();
    }

    public abstract class Command : ICommand
    {
        public string[] Aliases { get; set; }

        public abstract Task<int> InvokeAsync();
    }
}
