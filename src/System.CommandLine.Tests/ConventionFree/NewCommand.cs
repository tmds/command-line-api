using System.CommandLine.Tests.ConventionFree.Core;
using System.Threading.Tasks;

namespace System.CommandLine.Tests.ConventionFree
{
    public enum NugetPackageType
    {
        All = 0,
        Package = 1,
        Template = 2,
        Tool = 4
    }

    internal abstract class NewCommand : RootCommand
    {
        internal enum FilterType
        {
            Project,
            Item,
            Other
        }

        [Command(Hide: true)]
        internal abstract class NewHiddenNuGetCommand : NewCommand
        {
            public NewHiddenNuGetCommand()
            {
                TemplateNameOption = new Argument<string>(
                     suggestions: SuggestionFunc);
            }

            [Argument(help:"I still need help, ZOMBIES")]
            public Argument<string> TemplateNameOption { get; }
            [Option(alias: "lang", suggestions: new string[] { "C#", "VB", "F#", "FORTRAN 77" },
                help:"OMG Help me")]
            public string Language { get; }
            public bool Prerelease { get; set; }
            public string NugetSource { get; set; }

            // If you can, drop lambda and use a method directly
            public Func<string[]> SuggestionFunc
                => () => NugetSuggestions.GetSuggestions(PreRelease: Prerelease,
                            Match: TemplateNameOption, NugetSource: NugetSource,
                            PackageType: NugetPackageType.Template);

        }

        internal class NewInstallCommand : NewHiddenNuGetCommand
        {

            [Option(alias: "n")]
            public Option<string> Name { get; set; }

            [Option(alias: "o")]
            public string Output { get; set; }

            public bool Force { get; set; }

            public override Task<int> InvokeAsync()
            {
                string tName = TemplateNameOption.Value;
                throw new NotImplementedException();
            }
        }

        [Alias("l")]
        internal class NewListCommand : NewHiddenNuGetCommand
        {
            [Option()] // DefaultValue = FilterType.Project for C# 6
            public FilterType Type { get; set; } = FilterType.Project;

            public override Task<int> InvokeAsync()
                => throw new NotImplementedException();
        }

        internal class NewUninstallCommand : NewCommand
        {
            public NewUninstallCommand()
            {
                TemplateName = new Argument<string>(
                     suggestions: SuggestionFunc);
            }

            public Argument<string> TemplateName { get; private set; }

            private readonly string _templateDirectory = "";

            public  Func<string[]> SuggestionFunc
                => () => FileSuggestions.GetSuggestions(_templateDirectory);

            public override Task<int> InvokeAsync()
                => throw new NotImplementedException();
        }
    }
}
