using System.CommandLine.Tests.SampleDotNetCli.Core;
using System.Threading.Tasks;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    public enum NugetPackageType
    {
        All = 0,
        Package = 1,
        Template = 2,
        Tool = 4
    }

    internal abstract class NewCommand : RootCommand, ISupplySuggestionFunc
    {
        // Optional false is default, added here for clarity
        [Argument(Optional: false)]
        public string TemplateName { get; set; }

        public abstract Func<string[]> SuggestionFunc { get; }

        internal enum FilterType
        {
            Project,
            Item,
            Other
        }

        [Command(Hide: true)]
        internal abstract class NewHiddenNuGetCommand : NewCommand
        {
            [Option( Alias: "lang")]
            public string Language { get; set; }

            [Option()]
            public bool PreRelease { get; set; }

            [Optional]
            // TODO: Let's automate this alias based on capping in the name
            //[Alias("nuget-source", true)] 
            public string NugetSource { get; set; }

            // If you can, drop lambda and use a method directly
            public override Func<string[]> SuggestionFunc
                => () => NugetSuggestions.GetSuggestions(PreRelease: PreRelease,
                            Match: TemplateName, NugetSource: NugetSource,
                            PackageType: NugetPackageType.Template);

        }

        // dotnet foo --other-thing bar

        // Three ways to define name: InstallCommand (you disambiguate), NewInstallCommand (full-leaf name), specify in attribute
        // [Command(Name: "Install")]
        internal class NewInstallCommand : NewHiddenNuGetCommand
        {
            // KAD: How weird is "Option(Optional..." is switch better?
            [Option( Alias: "n")]
            public string Name { get; set; }

            [Option( Alias: "o")]
            public string Output { get; set; }

            [Option( )]
            public bool Force { get; set; }

            public override Task<int> InvokeAsync()
            {
                var x = TemplateName;
                throw new NotImplementedException();
            }
        }

        [Alias("l")]
        internal class NewListCommand : NewHiddenNuGetCommand
        {
            [Option( )] // DefaultValue = FilterType.Project for C# 6
            public FilterType Type { get; set; } = FilterType.Project;

            public override Task<int> InvokeAsync()
                => throw new NotImplementedException();
        }

        internal class NewUninstallCommand : NewCommand
        {
            private readonly string _templateDirectory = "";

            public override Func<string[]> SuggestionFunc
                => () => FileSuggestions.GetSuggestions(_templateDirectory);

            public override Task<int> InvokeAsync()
                => throw new NotImplementedException();
        }
    }
}
