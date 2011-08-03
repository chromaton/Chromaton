//------------------------------------------------------------------------------
// <copyright file="CursorTests.cs" company="(none)">
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

namespace Chromaton.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class CursorTests
    {
        [Datapoints]
        private string[] lineTerminators =
        {
            "\u000D",       // Carraige Return
            "\u000A",       // Line Feed
            "\u000D\u000A", // CRLF
            "\u0085",       // Next Line
            "\u000B",       // Vertical Tab
            "\u000C",       // Form Feed
            "\u2028",       // Line Separator
            "\u2029",       // Paragraph Separator
        };

        [Test]
        public void ctor_WhenGivenANullSubject_ThrowsException()
        {
            string subject = null;

            Assert.That(() => new Cursor(subject), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ctor_SetsTheOffestToZero()
        {
            string subject = "OK";

            var cursor = new Cursor(subject);

            Assert.That(cursor.Offset, Is.EqualTo(0));
        }

        [Test]
        public void ctor_SetsTheLineNumberToOne()
        {
            string subject = "OK";

            var cursor = new Cursor(subject);

            Assert.That(cursor.Line, Is.EqualTo(1));
        }

        [Test]
        public void ctor_SetsTheColumnNumberToOne()
        {
            string subject = "OK";

            var cursor = new Cursor(subject);

            Assert.That(cursor.Column, Is.EqualTo(1));
        }

        [Test]
        public void Advance_WhenAdvancingPastTheEndOfTheText_ThrowsException()
        {
            var subject = "OK_OK_OK_OK_OK";
            var cursor = new Cursor(subject);

            cursor.Advance(subject.Length);

            Assert.That(() => cursor.Advance(1), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void Advance_IncrementsTheOffset()
        {
            var subject = "OK_OK_OK_OK_OK";
            var cursor = new Cursor(subject);

            for (int i = 1; i <= subject.Length; i++)
            {
                cursor.Advance(1);
                Assert.That(cursor.Offset, Is.EqualTo(i));
            }
        }

        [Test]
        public void Advance_WhenOnASingleLine_IncrementsTheColumnNumber()
        {
            var subject = "OK_OK_OK_OK_OK";
            var cursor = new Cursor(subject);

            for (int i = 1; i <= subject.Length; i++)
            {
                cursor.Advance(1);
                Assert.That(cursor.Column, Is.EqualTo(i + 1));
            }
        }

        [Theory]
        public void Advance_WhenPassingALineTerminator_IncrementsTheLineNumber(string lineTerminator)
        {
            int count = 10;

            var subject = string.Join(string.Empty, from i in Enumerable.Range(0, count) select lineTerminator); // Create a subject containing 10 copies of the line terminator.
            var cursor = new Cursor(subject);

            for (int i = 1; i <= count; i++)
            {
                cursor.Advance(lineTerminator.Length);
                Assert.That(cursor.Line, Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void Advance_WhenPassingTheTheFirstCharacterOfCRLF_DoesNotIncrementTheLineNumber()
        {
            var subject = "OK\r\n";
            var cursor = new Cursor(subject);

            cursor.Advance("OK".Length + 1);

            Assert.That(cursor.Line, Is.EqualTo(1));
        }

        [Test]
        public void Advance_WhenPassingTheTheFirstCharacterOfCRLF_DoesNotIncrementTheColumnNumber()
        {
            var subject = "OK\r\n";
            var cursor = new Cursor(subject);

            cursor.Advance("OK".Length + 1);

            Assert.That(cursor.Column, Is.EqualTo(1 + "OK".Length));
        }

        [Theory]
        public void Advance_WhenPassingALineTerminator_ResetsTheColumnNumberToOne(string lineTerminator)
        {
            var subject = "OK" + lineTerminator + "OK";
            var cursor = new Cursor(subject);

            cursor.Advance("OK".Length + lineTerminator.Length);

            Assert.That(cursor.Column, Is.EqualTo(1));
        }

        [Test]
        public void Advance_WhenPassingLFWhichIsFollowedByCRLF_IncrementsTheColumnNumber()
        {
            var subject = "OK\n\r\n";
            var cursor = new Cursor(subject);

            cursor.Advance("OK".Length + 1);

            Assert.That(cursor.Line, Is.EqualTo(2));
        }
    }
}
