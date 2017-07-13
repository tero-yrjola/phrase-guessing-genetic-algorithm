using System;
using System.Linq;
using static GeneticAlgorithmTest.Form1;

namespace GeneticAlgorithmTest
{

    public class Helpers
    {
        private static readonly Random rng = new Random();

        public static bool AllowUpperCase = false;
        public static bool AllAsciiCharacters = false;

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
            if (AllAsciiCharacters) return (char) rng.Next(32, 127);

            int randomAlphabetInAscii =
                (randomAlphabetInAscii = rng.Next(64, 114)) > 90 //Skip over 6 ASCII-characters that aren't alphabets
                    ? randomAlphabetInAscii + 6
                    : randomAlphabetInAscii == 64
                        ? ' '
                        : randomAlphabetInAscii;

            if (AllowUpperCase) return (char) randomAlphabetInAscii;

            return char.ToLower((char) randomAlphabetInAscii);
        }
        public static char ReturnGeneticallyCloseChar(char currentCharacter)
        {
            if (AllAsciiCharacters)
            {
                return RandomAsciiCharWithNearLogic(currentCharacter);
            }

            int randomAlphabetInAscii =
                (randomAlphabetInAscii = rng.Next(64, 114)) > 90 //Skip over 6 ASCII-characters that aren't alphabets
                    ? randomAlphabetInAscii + 6
                    : randomAlphabetInAscii == 64
                        ? ' '
                        : randomAlphabetInAscii;

            if (AllowUpperCase) return (char) randomAlphabetInAscii;

            return char.ToLower((char) randomAlphabetInAscii);
        }

        private static char RandomAsciiCharWithNearLogic(char currentCharacter)
        {
            int s = rng.Next(32, 133);

            if (s > 126)
            {
                s = ConvertToCorrectNearAsciiCharacter(currentCharacter, s);
            }

            return (char)s;
        }

        private static int ConvertToCorrectNearAsciiCharacter(char currentCharacter, int s)
        {
            switch (s)
            {
                case 127:
                case 128:
                    s = currentCharacter - 1;                                       //One Ascii code smaller
                    break;

                case 129:
                case 130:
                    if (char.IsLower(currentCharacter)) s = currentCharacter - 32; //If lowercase, convert to uppercase and vice-versa
                    else s = currentCharacter + 32;
                    break;

                case 131:
                case 132:
                    s = currentCharacter + 1;                                       //One Ascii code bigger
                    break;
            }

            return s;
        }

        public static bool IsNearAsciiChar(char c1, char c2)
        {
            int character = Math.Abs(c1 - c2);
            if (character == 1 || character == 32) return true;
            return false;
        }

        public static decimal Numeric(object T)
        {
            return Convert.ToDecimal(T.ToString());
        }

        public class InputFieldValueException : Exception
        {
            public InputFieldValueException(string message) : base(message)
            {
            }
        }
    }
}