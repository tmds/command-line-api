// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.CommandLine.DragonFruit;

namespace SimpleExample
{
    public class Program
    {
        /// <summary>
        /// Hello
        /// </summary>
        /// <param name="verbose">Show verbose output</param>
        /// <param name="flavor">Which flavor to use</param>
        /// <param name="count">How many smoothies?</param>
        /// <param name="package"></param>
        /// <returns></returns>
        static int Main(
            bool verbose,
            [Alias("f")]
            Flavor flavor = Flavor.Chocolate,
            int count = 1,
            string package = null)
        {
            string[] PackageSuggestions()
            { return new string[] { "chocolate", "vanilla" }; }
            bool PackageValidation(string value)
            { return PackageSuggestions().Contains(value); }


            if (verbose)
            {
                Console.WriteLine("Running in verbose mode");
            }
            Console.WriteLine($"Creating {count} banana {(count == 1 ? "smoothie" : "smoothies")} with {flavor}");
            return 0;
        }
        enum Flavor
        {
            Chocolate,
            Vanilla,
            Strawberry
        }

    }
}
