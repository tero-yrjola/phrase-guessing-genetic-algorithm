using System;
using NSubstitute;
using NUnit.Framework;

namespace GeneticAlgorithmTest.Tests
{

    public class UnitTests
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
        public void GeneticallyCloseCharacterMappedCorrectly(int AsciiCode, char originalCharacter, char expectedResult)
        {
            Helpers.AllAsciiCharacters = true;
            ArrangeRngToReturn(AsciiCode);

            var result = Helpers.ReturnGeneticallyCloseChar(originalCharacter);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase('b','a', true)]
        [TestCase('b','b', false)]
        [TestCase('b','B', true)]
        [TestCase('b','c', true)]
        [TestCase('~','A', true)]
        [TestCase('A','~', true)]
        public void GeneticallyCloseCharacterFitnessCalculatedCorrectly(char c1, char c2, bool expected)
        {
            Assert.That(Helpers.Near(c1, c2), Is.EqualTo(expected));
        }

        [Test]
        public void geneticallycloselowercase()
        {
            Helpers.AllAsciiCharacters = false;
            Helpers.AllowUpperCase = false;
            Assert.That(Helpers.Near('a', 'z'), Is.EqualTo(true));
            Assert.That(Helpers.Near('z', 'a'), Is.EqualTo(true));
            Assert.That(Helpers.Near('d', 'e'), Is.EqualTo(true));
            Assert.That(Helpers.Near('e', 'd'), Is.EqualTo(true));
            Assert.That(Helpers.Near('a', 'z'), Is.EqualTo(true));
            Assert.That(Helpers.Near('a', 'c'), Is.EqualTo(false));
            Assert.That(Helpers.Near('a', 'x'), Is.EqualTo(false));
            Assert.That(Helpers.Near('x', 'g'), Is.EqualTo(false));
            Helpers.AllowUpperCase = true;
            Assert.That(Helpers.Near('a', 'Z'), Is.EqualTo(true));
            Assert.That(Helpers.Near('Z', 'a'), Is.EqualTo(true));
            Assert.That(Helpers.Near('d', 'e'), Is.EqualTo(true));
            Assert.That(Helpers.Near('e', 'd'), Is.EqualTo(true));
            Assert.That(Helpers.Near('a', 'z'), Is.EqualTo(true));
            Assert.That(Helpers.Near('a', 'z'), Is.EqualTo(false));
            Assert.That(Helpers.Near('z', 'a'), Is.EqualTo(false));
            Assert.That(Helpers.Near('x', 'g'), Is.EqualTo(false));
        }

        public void ArrangeRngToReturn(int returnValue)
        {
            testRng.Next(Arg.Any<int>(), Arg.Any<int>()).Returns(returnValue);
        }
    }
}