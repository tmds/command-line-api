using System.Threading.Tasks;

namespace System.CommandLine.Tests.SampleDotNetCli.Core
{
    // LATER: Place interface in a separate file
    public interface ICommand
    {
        string[] Aliases { get; set; }

        Task<int> Invoke();
    }

    public abstract class Command : ICommand
    {
        public string[] Aliases { get; set; }

        public abstract Task<int> Invoke();
    }
}
