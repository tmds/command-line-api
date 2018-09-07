using System.Threading.Tasks;

namespace System.CommandLine.Tests.SampleDotNetCli.Core
{
    public abstract class Command
    {
        public string[] Aliases { get; set; }

        public abstract Task<int> Invoke();
    }
}
