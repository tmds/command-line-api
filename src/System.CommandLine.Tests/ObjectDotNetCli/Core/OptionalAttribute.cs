using System;
using System.Collections.Generic;
using System.Text;

namespace System.CommandLine.Tests.ObjectDotNetCli.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    class OptionalAttribute : Attribute
    {
    }
}
