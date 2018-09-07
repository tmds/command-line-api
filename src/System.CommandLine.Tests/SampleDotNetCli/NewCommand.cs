using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.CommandLine.Tests.SampleDotNetCli
{


    internal class NewCommand : RootCommand
    {
        public NewCommand(string templateName)
        {
            TemplateName = templateName;
        }
        public string TemplateName { get; set; }

        public override Task<int> Invoke()
        {
            throw new NotImplementedException();
        }
    }
}
