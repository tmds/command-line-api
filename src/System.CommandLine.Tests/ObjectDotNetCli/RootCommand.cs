using System.Threading.Tasks;
using System.CommandLine.Tests.ObjectDotNetCli.Core;

namespace System.CommandLine.Tests.ObjectDotNetCli
{
    internal class RootCommand : Core.Command
    {
        // TODO: Let's automate this alias based on capping in the name
        public bool Info { get; set; }
        public bool Version { get; set; }
        public bool ListRuntimes{ get; set; }
        public bool ListSdks { get; set; }

        [Alias("d")]
        public bool Diagnostics { get; set; }

        // TODO: If we use inheritance, we will need to do something other than abstract to indicate not invokable, currently just this. 
        public override  Task<int> InvokeAsync()
        {
            // TODO: Preserve existing behavior on combined options (error or all or order of use)
            if (Info)
            {
               return Task.FromResult(OutputInfo());
            }
            if (Version)
            {
                return Task.FromResult(OutputVersion());
            }
            if (ListRuntimes)
            {
                return Task.FromResult(OutputRuntimes());
            }
            if (ListSdks)
            {
                return Task.FromResult(OutputSdks());
            }
            return Task.FromResult(0);
        }

        private int OutputSdks() => throw new NotImplementedException();
        private int OutputRuntimes() => throw new NotImplementedException();
        private int OutputVersion() => throw new NotImplementedException();
        private int OutputInfo() => throw new NotImplementedException();
    }
}
