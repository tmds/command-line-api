using System;
using System.Collections.Generic;
using System.Text;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Parent command cannot short circuit a subcommand if the subcommand is specified on the
            // command line.  e.g. dotnet --info new "console" will cause the new subcommand to run and not
            // the dotnet rootcommand processing --info.
            var x = CommandLine.Builder.GetParser();
            var result = x.Parse(args);
            if (Help or bail)
                { }
            result.Invoke<RootCommand>(args);

        }
    }
}
