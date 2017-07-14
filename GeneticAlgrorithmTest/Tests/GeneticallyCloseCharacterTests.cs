using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace GeneticAlgorithmTest.Tests
{

    public class GeneticallyCloseCharacterTests
    {
        public static Random testRng;

        [Test]
        public void testRngMappedToHelpers()
        {
            ArrangeRngToReturn(50);
            Assert.That(testRng.Next(10, 20), Is.EqualTo(50));
        }

        [TestCase(132, 'b', 'c')]
        [TestCase(130, 'b', 'B')]
        [TestCase(128, 'b', 'a')]
        [TestCase(98, 'b', 'b')]
        [TestCase(132, '~', 'A')]
        [TestCase(128, 'A', '~')]
        public void GeneticallyCloseAsciiCharacterMappedCorrectly(int AsciiCode, char originalCharacter, char expectedResult)
        {
            Helpers.AllAsciiCharacters = true;
            ArrangeRngToReturn(AsciiCode);

            var result = Helpers.ReturnGeneticallyCloseChar(originalCharacter);
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [TestCase('a', 'b', true)]
        [TestCase('a', ' ', true)]
        [TestCase('a', 'z', false)]
        [TestCase('a', 'c', false)]
        public void GeneticallyNearLowerCaseTests(char c1, char c2, bool expected)
        {
            Helpers.AllAsciiCharacters = false;
            Helpers.AllowUpperCase = false;

            Assert.That(Helpers.Near(c1, c2), Is.EqualTo(expected));
        }

        [TestCase('a', 'b', true)]
        [TestCase('a', 'Z', true)]
        [TestCase('A', ' ', true)]
        [TestCase('a', 'c', false)]
        [TestCase('a', 'B', false)]
        public void GeneticallyNearUpperCaseTests(char c1, char c2, bool expected)
        {
            Helpers.AllowUpperCase = true;

            Assert.That(Helpers.Near(c1, c2), Is.EqualTo(expected));
        }

        [TestCase(' ', '~', true)]
        [TestCase('a', 'A', true)]
        [TestCase('2', 'R', false)]
        [TestCase('a', 'B', false)]
        [TestCase('a', 'Z', false)]
        public void GeneticallyNearAllAsciiTests(char c1, char c2, bool expected)
        {
            Helpers.AllAsciiCharacters = true;

            Assert.That(Helpers.Near(c1, c2), Is.EqualTo(expected));
        }

        public void ArrangeRngToReturn(int returnValue)
        {
            testRng.Next(Arg.Any<int>(), Arg.Any<int>()).Returns(returnValue);
        }
    }
}