using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.CommandLine.Tests.SampleDotNetCli.Core;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    internal class NewCommand : RootCommand
    {
        [Optional]
        [Alias("n")]
        public string? Name { get; set; }

        [Optional]
        [Alias("o")]
        public string? Output { get; set; }

        [Optional]
        public bool Force { get; set; }

        [Optional][Alias("lang")]
        public string Language { get; set; }

        public NewCommand(string templateName)
        {
            TemplateName = templateName;
        }
        public string TemplateName { get; set; }

        public override Task<int> Invoke()
        {
            throw new NotImplementedException();
        }

        [Optional]
        [Alias("nuget-source", true)]
        public string NugetSource { get; set; }

        internal enum FilterType
        {
            Project,
            Item,
            Other
        }


        internal class InstallCommand : NewCommand
        {
            public string TemplateName { get; set; }

            public new override Task<int> Invoke()
            {
                throw new NotImplementedException();
            }
        }

        internal class UninstallCommand : NewCommand
        {
            public string TemplateName { get; set; }

            public new override Task<int> Invoke()
            {
                throw new NotImplementedException();
            }
        }

        [Alias("l")]
        internal class ListCommand : NewCommand
        {
            [Optional]
            public FilterType Type { get; set; }

            public override Task<int> Invoke()
            {
                throw new NotImplementedException();
            }
        }
    }
}
