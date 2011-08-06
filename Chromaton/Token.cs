//------------------------------------------------------------------------------
// <copyright file="Token.cs" company="(none)">
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

namespace Chromaton
{
    using System;

    public class Token
    {
        private readonly int startOffset;
        private readonly int endOffset;
        private readonly string tokenClass;

        public Token(int startOffset, int endOffset, string tokenClass)
        {
            if (startOffset < 0)
            {
                throw new ArgumentOutOfRangeException("startOffset");
            }

            if (endOffset <= startOffset)
            {
                throw new ArgumentOutOfRangeException("endOffset");
            }

            if (string.IsNullOrEmpty(tokenClass))
            {
                throw new ArgumentNullException("tokenClass");
            }

            this.startOffset = startOffset;
            this.endOffset = endOffset;
            this.tokenClass = tokenClass;
        }

        public int StartOffset
        {
            get { return this.startOffset; }
        }

        public int EndOffset
        {
            get { return this.endOffset; }
        }

        public string TokenClass
        {
            get { return this.tokenClass; }
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", this.startOffset, this.endOffset, this.tokenClass);
        }
    }
}
