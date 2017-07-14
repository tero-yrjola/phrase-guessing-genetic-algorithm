using System;
using System.Linq;
using NSubstitute.Exceptions;
using static GeneticAlgorithmTest.Form1;

namespace GeneticAlgorithmTest
{

    public class Helpers
    {
        public static Random rng = new Random();

        public static bool AllowUpperCase = false;
        public static bool AllAsciiCharacters = false;

        private const string LowerCaseCharactersString = " abcdefghijklmnopqrstuvwxyz";
        private const string UpperCaseCharactersString = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string AllAsciiCharactersString = " !\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

        private static int numberOfCurrentAlphabets;

        private static string currentSetOfAlphabets
        {
            get
            {
                if (AllAsciiCharacters) return AllAsciiCharactersString;
                else if (AllowUpperCase) return UpperCaseCharactersString;
                else return LowerCaseCharactersString;
            }
        }

        private static int numberOfNeighbours
        {
            get
            {
                if (!AllowUpperCase) return 4;
                else return 6;
            }
        }

        public static string ReturnValidPopulation(string valueString)
        {
            try
            {
                string s = string.IsNullOrWhiteSpace(valueString)
                    ? DefaultPopulation
                    : Numeric(valueString) <= 0 || Numeric(valueString) >= 1000001
                        ? "-1"
                        : valueString;

                if (s == "-1") throw new FormatException();
                return s;
            }
            catch (FormatException)
            {
                throw new InputFieldValueException("Population has to be an integer between 1 and 1,000,000.");
            }
        }

        public static string ReturnValidPercentage(string valueString)
        {
            valueString = valueString.Replace('.', ',');

            try
            {
                string s = string.IsNullOrWhiteSpace(valueString)
                    ? DefaultPercentage
                    : Numeric(valueString) <= 0 || Numeric(valueString) >= 1
                        ? "-1"
                        : valueString;

                if (s == "-1") throw new FormatException();
                return s;
            }
            catch (FormatException)
            {
                throw new InputFieldValueException(
                    "Mutation rate / elite percentage has to be a decimal between 0 and 1.");
            }
        }

        public static string CheckPhraseLegitimacy(string s)
        {
            if (s?.Length < 1) throw new InputFieldValueException("Phrase invalid!");

            if (AllowUpperCase)
            {
                if (AllAsciiCharacters)
                {
                    if (s.All(ch => ch < 127)) return s;
                }
                else
                {
                    if (s.All(ch => char.IsLetter(ch) || ch == ' ')) return s;
                }
            }
            else
            {
                if (s.All(ch => char.IsLower(ch) || ch == ' ')) return s;
            }

            throw new InputFieldValueException("Phrase invalid!");
        }

        public static char ReturnRandomChar()
        {
            return currentSetOfAlphabets[rng.Next(0, currentSetOfAlphabets.Length)];
        }

        /*Logic is to generate a random number from the set alphabet + extra number of neighbours. If the extra get hit, then those hits get converted
         to a neighbouring alphabet or a change in case.*/
        public static char ReturnGeneticallyCloseChar(char currentCharacter)
        {
            numberOfCurrentAlphabets = currentSetOfAlphabets.Length;
            int randomIndex = rng.Next(0, numberOfCurrentAlphabets + numberOfNeighbours);

            if (randomIndex >= numberOfCurrentAlphabets)
            {
                randomIndex = ConvertToCorrectNearCharacter(currentCharacter, randomIndex);
            }
            else randomIndex = currentSetOfAlphabets[randomIndex];

            return (char)randomIndex;
            }

        private static int ConvertToCorrectNearCharacter(char currentCharacter, int randomIndex)
        {
            if (randomIndex == numberOfCurrentAlphabets ||
                randomIndex == numberOfCurrentAlphabets + 1)
            return RotateRight(currentSetOfAlphabets)[currentSetOfAlphabets.IndexOf(currentCharacter)];

            if (randomIndex == numberOfCurrentAlphabets +2 ||
                randomIndex == numberOfCurrentAlphabets +3)
                return RotateLeft(currentSetOfAlphabets)[currentSetOfAlphabets.IndexOf(currentCharacter)];

            return ChangeCase(currentCharacter);
        }

        /*The method calculates if two characters are next to eachother. 
         * Alphabet starts from ' ' and then (in lower case) a, b, c ... y, z.
         * Rollovers can happen, so ' ' is a neighbour (in lower case) of 'z'.
         * Only one step ("Move 1 step in alphabet" OR "change case") is allowed. Therefore 'a' and 'B' are NOT neighbours.
         * Special characters are neighbours with themselves.
         */

        public static bool Near(char c1, char c2)
        {
            if (Math.Abs(currentSetOfAlphabets.IndexOf(c1) - currentSetOfAlphabets.IndexOf(c2)) <= 1) return true;

            if (ChangeCase(c1) == c2) return true;

            if (Math.Abs(RotateRight(currentSetOfAlphabets).IndexOf(c1) -
                         RotateRight(currentSetOfAlphabets).IndexOf(c2)) <= 1) return true;

            return false;
        }

        public static decimal Numeric(object T)
        {
            return Convert.ToDecimal(T.ToString());
        }

        public static char ChangeCase(char c)
        {
            if (65 <= c && c <= 90) return (char)(c + 32);
            if (97 <= c && c <= 122) return (char)(c - 32);
            return c;
        }

        public static string RotateLeft(string s)
        {
            return s.Substring(1, s.Length - 1) + s.Substring(0, 1);
        }

        public static string RotateRight(string s)
        {
            return s.Substring(s.Length - 1) + s.Substring(0, s.Length - 1);
        }

        public class InputFieldValueException : Exception
        {
            public InputFieldValueException(string message) : base(message)
            {
            }
        }
    }
}