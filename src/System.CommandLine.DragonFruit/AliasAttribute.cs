using System;
using System.Collections.Generic;
using System.Text;

namespace System.CommandLine.DragonFruit
{
    [System.AttributeUsage(System.AttributeTargets.Parameter | System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class AliasAttribute : System.Attribute
    {
        public AliasAttribute(params string[] aliases)
        {
            _aliases = aliases;
        }
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;
        private readonly System.String[] _aliases;

    }
}
