//------------------------------------------------------------------------------
// <copyright file="Cursor.cs" company="(none)">
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
    using Chromaton.Properties;

    public class Cursor
    {
        private readonly string text;

        private int offset;

        private int line;
        private int column;

        public Cursor(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            this.text = text;

            this.offset = 0;
            this.line = 1;
            this.column = 1;
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
        }

        public int Line
        {
            get
            {
                return this.line;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }
        }

        public void Advance(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.AdvanceCharacter();
            }
        }

        private void AdvanceCharacter()
        {
            if (this.offset == this.text.Length)
            {
                throw new InvalidOperationException(Resources.CursorAdvancedTooFar);
            }

            switch (this.text[this.offset])
            {
                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u0085':
                case '\u2028':
                case '\u2029':
                    this.line++;
                    this.column = 1;
                    break;

                case '\u000D':
                    if (this.text.Length == this.offset + 1 || this.text[this.offset + 1] != '\u000A')
                    {
                        this.line++;
                        this.column = 1;
                    }

                    break;

                default:
                    this.column++;
                    break;
            }

            this.offset++;
        }
    }
}
