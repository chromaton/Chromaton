//------------------------------------------------------------------------------
// <copyright file="BrainfuckLexerTests.cs" company="(none)">
//  This file is part of Chromaton.
//
//  Chromaton is free software: you can redistribute it and/or modify it under
//  the terms of the Lesser GNU General Public License as published by the Free
//  Software Foundation, either version 3 of the License, or (at your option)
//  any later version.
//
//  Chromaton is distributed in the hope that it will be useful, but WITHOUT ANY
//  WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
//  FOR A PARTICULAR PURPOSE.  See the Lesser GNU General Public License for
//  more details.
//
//  You should have received a copy of the Lesser GNU General Public License
//  along with Chromaton.  If not, see http://www.gnu.org/licenses/.
// </copyright>
// <author>John Gietzen</author>
//------------------------------------------------------------------------------

namespace Chromaton.Tests.LexerTests
{
    using System;
    using Chromaton.Lexers;
    using NUnit.Extensions;
    using NUnit.Framework;

    [TestFixture]
    public class BrainfuckLexerTests
    {
        private readonly string[] lexerApprovals;

        public BrainfuckLexerTests()
        {
            this.lexerApprovals = Expectation.DiscoverTestCases("Chromaton.Tests.Expectations.BrainfuckLexerTests.Tokenize");
        }

        [Test]
        public void Tokenize_WhenCalledWithANullSource_ThrowsException()
        {
            var lexer = (ILexer)new BrainfuckLexer();

            Assert.That(() => lexer.Tokenize(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        [TestCaseSource("lexerApprovals")]
        public void approve_Tokenize(string testCase)
        {
            var test = Expectation.GetTestData(testCase);
            var lexer = (ILexer)new BrainfuckLexer();

            var result = lexer.Tokenize(test);

            Expectation.Check(result, testCase);
        }
    }
}
