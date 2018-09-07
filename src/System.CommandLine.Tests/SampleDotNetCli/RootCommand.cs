using System.Threading.Tasks;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    internal abstract class RootCommand : Core.Command
    {
        public bool Info { get; set; }
    }
}
