// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.CommandLine.Builder;
using FluentAssertions;
using Xunit;

namespace System.CommandLine.Tests.ConventionFree
{
    public class ConventionFreeTests
    {
        [Fact]
        public void Builder_can_be_created()
        {
            var builder = ConventionFreeHelpers.MakeCommandBuilder<RootCommand>();
             builder.Should().NotBeNull();
        }
    }
} 
