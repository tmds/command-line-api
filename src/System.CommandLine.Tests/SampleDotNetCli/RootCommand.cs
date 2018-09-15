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

        // TODO: Let's automate this alias based on capping in the name
        // [Alias("list-runtimes", true)]
        public bool ListRuntimes{ get; set; }

        // TODO: If we use inheritance, we will need to do something other than abstract to indicate not invokable, currently just this. 
        public override Task<int> InvokeAsync() => throw new NotImplementedException();
    }
}
