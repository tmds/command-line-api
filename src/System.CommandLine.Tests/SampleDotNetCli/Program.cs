using System;
using System.Collections.Generic;
using System.Text;

namespace System.CommandLine.Tests.SampleDotNetCli
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Parent command cannot short circuit a subcommand if the subcommand is specified on the
            // command line.  e.g. dotnet --info new "console" will cause the new subcommand to run and not
            // the dotnet rootcommand processing --info.
            CommandLineParser.Invoke<RootCommand>(args);

        }
    }
}
