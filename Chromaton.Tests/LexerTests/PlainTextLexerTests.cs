//------------------------------------------------------------------------------
// <copyright file="PlainTextLexerTests.cs" company="(none)">
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
    using System.Linq;
    using Chromaton.Lexers;
    using NUnit.Framework;

    [TestFixture]
    public class PlainTextLexerTests
    {
        [Test]
        public void Tokenize_WhenCalledWithAnEmptySource_YieldsNoTokens()
        {
            var lexer = (ILexer)new PlainTextLexer();

            var result = lexer.Tokenize(string.Empty);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Tokenize_WhenCalledWithANullSource_ThrowsException()
        {
            var lexer = (ILexer)new PlainTextLexer();

            Assert.That(() => lexer.Tokenize(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Tokenize_WhenCalledWithANonEmptySource_YieldsASingleToken()
        {
            var lexer = (ILexer)new PlainTextLexer();
            var source = " OK OK OK OK OK OK OK OK ";

            var token = lexer.Tokenize(source).Single();

            Assert.Pass();
        }

        [Test]
        public void Tokenize_SingleYieldedToken_MatchesWholeSource()
        {
            var lexer = (ILexer)new PlainTextLexer();
            var source = " OK OK OK OK OK OK OK OK ";

            var result = lexer.Tokenize(source).Single();

            Assert.That(result.StartOffset, Is.EqualTo(0));
            Assert.That(result.EndOffset, Is.EqualTo(source.Length));
        }

        [Test]
        public void Tokenize_SingleYieldedToken_IsOfTypeText()
        {
            var lexer = (ILexer)new PlainTextLexer();
            var source = " OK OK OK OK OK OK OK OK ";

            var result = lexer.Tokenize(source).Single();

            Assert.That(result.TokenClass, Is.StringMatching(@"^Text(\.|$)"));
        }
    }
}
