using System.Threading.Tasks;
using System.CommandLine.Tests.SampleDotNetCli.Core;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    internal abstract class RootCommand : Core.Command
    {
        public bool Info { get; set; }
        public bool Version { get; set; }

        [Alias("d")]
        public bool Diagnostics { get; set; }

        [Alias("list-runtimes", true)]
        public bool ListRuntimes{ get; set; }

    }
}
