using System.CommandLine.Tests.SampleDotNetCli.Core;
using System.Threading.Tasks;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    internal class NewCommand : RootCommand
    {
        // KAD: How weird is "Option(Optional"
        [Option(Optional: true, Alias: "n")]
        public string Name { get; set; }

        // KAD: Remove old attributes if we adopt the new attribute style
        [Optional]
        [Alias("o")]
        public string Output { get; set; }

        [Optional]
        public bool Force { get; set; }

        [Optional]
        [Alias("lang")]
        public string Language { get; set; }

        public override Task<int> Invoke()
        {
            throw new NotImplementedException();
        }

        [Optional]
        // TODO: Let's automate this alias based on capping in the name
        //[Alias("nuget-source", true)] 
        public string NugetSource { get; set; }

        internal enum FilterType
        {
            Project,
            Item,
            Other
        }

        public enum NuGetPackageType
        {
            All = 0,
            Package = 1,
            Template = 2,
            Tool = 4
        }

        public class NuGetSuggestions
        {
            public NuGetSuggestions(NuGetPackageType PackageType = NuGetPackageType.Package)
            {
                // Do the work
            }
        }

        internal class NewInstallCommand : NewCommand
        {
            [Argument()]
            public string TemplateName { get; set; }

            public override Task<int> Invoke()
            {
                throw new NotImplementedException();
            }
        }

        internal class NewUninstallCommand : NewCommand
        {
            [Argument()]
            public string TemplateName { get; set; }

            public override Task<int> Invoke()
            {
                throw new NotImplementedException();
            }
        }

        [Alias("l")]
        internal class NewListCommand : NewCommand
        {
            [Option(Optional: true)]
            public FilterType? Type { get; set; }

            public override Task<int> Invoke()
            {
                throw new NotImplementedException();
            }
        }
    }
}
