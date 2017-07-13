using System;
using NSubstitute;
using NUnit.Framework;

namespace GeneticAlgorithmTest.Tests
{
    [SetUpFixture]
    public class SetupFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            UnitTests.testRng = Substitute.For<Random>();
            Helpers.rng = UnitTests.testRng;
        }
    }
}