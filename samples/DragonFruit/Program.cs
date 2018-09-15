// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.CommandLine.DragonFruit;

public class Program
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="diagnostics"></param>
    /// <param name="info"></param>
    /// <param name="listRuntimes"></param>
    /// <param name="listSdks"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    static int Main(
        [Alias("d")]
        bool diagnostics,
        bool info,
        [Alias("list-runtimes")]
        bool listRuntimes,
        [Alias("list-sdks")]
        bool listSdks,
        bool version)
    {

        return 0;
    }

    public class New
    {
        public static int Main([Alias("n")]string name = null, [Alias("o")]string output = null, bool force = false)
        {
            return 42;
        }

        [Alias("l")]
        public class List
        {
            static int Main(ListType? type = null, [Alias("lang")] string language = null)
            {
                string[] LanguageSuggestions(){ return new string[] { "C#", "F#", "VB", "COBOL" }; }
                bool LanguageValidation(string value)
                    { return LanguageSuggestions().Contains(value); }
                return 42;

            }

            enum ListType{Project, Item, Other}
        }

        [Alias("i")]
        public class Install
        {
            static int Main(string target)
            {
                return 42;

            }
        }
        [Alias("u")]
        class Uninstall
        {
            static int Main(string target)
            {
                return 42;

            }
        }
    }
}
