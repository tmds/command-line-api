using System;
using System.Collections.Generic;
using System.Text;

namespace System.CommandLine.Tests.ObjectDotNetCli.Core
{
    public static class NugetSuggestions 
    {
        public static string[] GetSuggestions(bool PreRelease = false,
            NugetPackageType PackageType = NugetPackageType.All,
            string NugetSource = null, string Match = null )
            => throw new NotImplementedException();
    }
}
