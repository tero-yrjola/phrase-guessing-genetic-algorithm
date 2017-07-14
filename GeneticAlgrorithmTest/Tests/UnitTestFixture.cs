using System;
using NSubstitute;
using NUnit.Framework;

namespace GeneticAlgorithmTest.Tests
{
    [SetUpFixture]
    public class UnitTests
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            GeneticallyCloseCharacterTests.testRng = Substitute.For<Random>();
            Helpers.rng = GeneticallyCloseCharacterTests.testRng;
        }
    }
}