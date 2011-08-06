//------------------------------------------------------------------------------
// <copyright file="TokenTests.cs" company="(none)">
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
    using NUnit.Framework;

    [TestFixture]
    public class TokenTests
    {
        [Test]
        public void ctor_WhenCalledWithValidValues_Succeeds()
        {
            var token = new Token(0, 1, "OK");
        }

        [Test]
        public void ctor_WithANegativeStartOffset_ThrowsException()
        {
            Assert.That(() => new Token(-1, 1, "OK"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ctor_WithANegativeEndOffset_ThrowsException()
        {
            Assert.That(() => new Token(0, -1, "OK"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ctor_WithAStartOffsetGreaterThanTheEndOffset_ThrowsException()
        {
            Assert.That(() => new Token(1, 0, "OK"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ctor_WithAStartOffsetEqualToTheEndOffset_ThrowsException()
        {
            Assert.That(() => new Token(0, 0, "OK"), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ctor_WhenCalledWithANullTokenClass_ThrowsException()
        {
            Assert.That(() => new Token(0, 1, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ctor_WhenCalledWithAnEmptyTokenClass_ThrowsException()
        {
            Assert.That(() => new Token(0, 1, string.Empty), Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
