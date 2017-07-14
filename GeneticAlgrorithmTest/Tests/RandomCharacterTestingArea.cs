using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace GeneticAlgorithmTest.Tests
{
    public class RandomCharacterTestingArea
    {
        public static Random testRng;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            testRng = Substitute.For<Random>();
            Helpers.rng = testRng;
        }

        [Test]
        public void RandomCharacterWithNearLogicTestingArea()
        {
            List<char> list = new List<char>();


            /** FOR LOWERCASE **/
            Helpers.AllAsciiCharacters = false;
            Helpers.AllowUpperCase = false;

            for (int i = 96; i < 123; i++)
            {
                ArrangeRngToReturn(i);
                list.Add(Helpers.ReturnRandomChar());
            }

            list.ToString();
            list.Clear();

            for (int i = 96; i < 127; i++)
            {
                ArrangeRngToReturn(i);
                list.Add(Helpers.ReturnGeneticallyCloseChar('a'));
            }

            list.ToString();
            list.Clear();

            /** FOR  UPPER- AND LOWERCASE **/
            Helpers.AllAsciiCharacters = false;
            Helpers.AllowUpperCase = true;

            for (int i = 64; i < 117; i++)
            {
                ArrangeRngToReturn(i);
                list.Add(Helpers.ReturnRandomChar());
            }

            list.ToString();
            list.Clear();

            for (int i = 64; i < 123; i++)
            {
                ArrangeRngToReturn(i);
                list.Add(Helpers.ReturnGeneticallyCloseChar('a'));
            }

            list.ToString();
            list.Clear();

            /** FOR ALL **/
            Helpers.AllAsciiCharacters = true;

            for (int i = 32; i < 127; i++)
            {
                ArrangeRngToReturn(i);
                list.Add(Helpers.ReturnRandomChar());
            }

            list.ToString();
            list.Clear();

            for (int i = 32; i < 133; i++)
            {
                ArrangeRngToReturn(i);
                list.Add(Helpers.ReturnRandomChar());
            }
        }
        public void ArrangeRngToReturn(int returnValue)
        {
            testRng.Next(Arg.Any<int>(), Arg.Any<int>()).Returns(returnValue);
        }
    }
}