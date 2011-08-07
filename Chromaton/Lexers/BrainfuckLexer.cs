//------------------------------------------------------------------------------
// <copyright file="BrainfuckLexer.cs" company="(none)">
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

namespace Chromaton.Lexers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class BrainfuckLexer : LexerBase
    {
        private static readonly string operators = "<>+-.,";
        private static readonly string grouping = "[]";
        private static readonly Regex whitespace = new Regex(@"[\s]+", RegexOptions.Compiled);
        private static readonly Regex nonOperator = new Regex(@"[^-+[\]<>.,]+", RegexOptions.Compiled);

        protected override IEnumerable<Token> Tokenize(string source)
        {
            Cursor c = new Cursor(source);
            while (c.Offset < source.Length)
            {
                var currentChar = source[c.Offset];

                if (operators.Contains(currentChar))
                {
                    yield return new Token(c.Offset, c.Offset + 1, "Operator.Symbol");
                    c.Advance(1);
                    continue;
                }

                if (grouping.Contains(currentChar))
                {
                    yield return new Token(c.Offset, c.Offset + 1, "Grouping.Statements");
                    c.Advance(1);
                    continue;
                }

                var match = whitespace.Match(source, c.Offset);
                if (match.Success && match.Index == c.Offset)
                {
                    yield return new Token(c.Offset, c.Offset + match.Length, "Whitespace.Insignificant");
                    c.Advance(match.Length);
                    continue;
                }

                match = nonOperator.Match(source, c.Offset);
                yield return new Token(c.Offset, c.Offset + match.Length, "Comment.Block");
                c.Advance(match.Length);
            }
        }
    }
}
