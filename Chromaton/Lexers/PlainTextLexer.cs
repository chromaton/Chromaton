//------------------------------------------------------------------------------
// <copyright file="PlainTextLexer.cs" company="(none)">
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
    using System;
    using System.Collections.Generic;

    public class PlainTextLexer : ILexer
    {
        public IEnumerable<Token> Tokenize(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return this.TokenizeImpl(source);
        }

        private IEnumerable<Token> TokenizeImpl(string source)
        {
            if (source.Length == 0)
            {
                yield break;
            }

            yield return new Token(0, source.Length, "Text.Plain");
        }
    }
}
