using System;
using System.Linq;
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
            if (AllAsciiCharacters) return (char)rng.Next(32, 127);

            else if (AllowUpperCase)
            {
                int randomAlphabetInAscii =
                    (randomAlphabetInAscii = rng.Next(64, 117)) > 90
                        ? randomAlphabetInAscii + 6                     //Skip over 6 ASCII-characters that aren't alphabets
                        : randomAlphabetInAscii == 64
                            ? ' '                                       // If Ascii code is 64, convert it to a space
                            : randomAlphabetInAscii;

                return (char)randomAlphabetInAscii;
            }
            else
            {
                int randomAlphabetInAscii =
                    (randomAlphabetInAscii = rng.Next(96, 123)) == 96
                        ? ' ' 
                        : randomAlphabetInAscii;
            return char.ToLower((char)randomAlphabetInAscii);
            }
        }

        /*Logic is to generate a random number from ASCII-codes + 6. If the extra 6 get hit, then those hits get converted
         to a neighbouring alphabet or a change in case.*/
        public static char ReturnGeneticallyCloseChar(char currentCharacter)
        {
            if (AllAsciiCharacters)
            {
                return RandomAsciiCharWithNearLogic(currentCharacter);
            }
            if (AllowUpperCase)
            {
                return RandomUpperCaseCharWithNearLogic(currentCharacter);
            }

            return RandomLowerCaseCharacterWithNearLogic(currentCharacter);
        }

        private static char RandomLowerCaseCharacterWithNearLogic(char currentCharacter)
        {
            int randomAlphabetInAscii =
                (randomAlphabetInAscii = rng.Next(96, 127)) == 96
                    ? ' '
                    : randomAlphabetInAscii;
            if (randomAlphabetInAscii > 122)
            {
                randomAlphabetInAscii = ConvertToCorrectNearLowerCaseCharacter(currentCharacter, randomAlphabetInAscii);
            }
            return (char)randomAlphabetInAscii;
        
    }

        private static int ConvertToCorrectNearLowerCaseCharacter(char currentCharacter, int randomAlphabetInAscii)
        {
            switch (randomAlphabetInAscii)
            {
                case 123:
                case 124:
                    if (currentCharacter == ' ') return 'z';
                    randomAlphabetInAscii = currentCharacter - 1;                                       //One Ascii code smaller
                    break;

                case 125:
                case 126:
                    if (currentCharacter == ' ') return 'a';
                    randomAlphabetInAscii = currentCharacter + 1;                                       //One Ascii code bigger
                    break;
            }

            return randomAlphabetInAscii < 97 ? ' ' :
                randomAlphabetInAscii > 122 ? ' ' : randomAlphabetInAscii;
        }

        private static char RandomUpperCaseCharWithNearLogic(char currentCharacter)
        {
            if (currentCharacter == ' ') currentCharacter = (char) 64;
            int randomAlphabetInAscii =
                (randomAlphabetInAscii = rng.Next(64, 128)) > 90
                    ? randomAlphabetInAscii + 6                         //Skip over 6 ASCII-characters that aren't alphabets
                    : randomAlphabetInAscii == 64
                        ? ' '
                        : randomAlphabetInAscii;
            if (randomAlphabetInAscii > 122)
            {
                randomAlphabetInAscii = ConvertToCorrectNearUpperCaseCharacter(currentCharacter, randomAlphabetInAscii);
            }
            return (char)randomAlphabetInAscii;
        }

        private static int ConvertToCorrectNearUpperCaseCharacter(char currentCharacter, int randomAlphabetInAscii)
        {
            switch (randomAlphabetInAscii)
            {
                case 123:
                case 124:
                    if (currentCharacter == 64) return 'z';
                    randomAlphabetInAscii = currentCharacter - 1;                                       //One Ascii code smaller
                    randomAlphabetInAscii = randomAlphabetInAscii < 65 ? ' ' : randomAlphabetInAscii;
                    break;

                case 125:
                case 126:
                    if (currentCharacter == 64) return ' ';
                    if (char.IsLower(currentCharacter)) randomAlphabetInAscii = currentCharacter - 32; //If lowercase, convert to uppercase and vice-versa
                    else randomAlphabetInAscii = currentCharacter + 32;
                    break;

                case 127:
                case 128:
                    if (currentCharacter == 64) return 'A';
                    randomAlphabetInAscii = currentCharacter + 1;                                       //One Ascii code bigger
                    randomAlphabetInAscii = randomAlphabetInAscii > 122 ? ' ' : randomAlphabetInAscii;
                    break;
            }

            return randomAlphabetInAscii;
        }

        private static char RandomAsciiCharWithNearLogic(char currentCharacter)
        {
            int randomAscii = rng.Next(32, 133);

            if (randomAscii > 126)
            {
                randomAscii = ConvertToCorrectNearAsciiCharacter(currentCharacter, randomAscii);
            }

            return (char)randomAscii;
        }

        private static int ConvertToCorrectNearAsciiCharacter(char currentCharacter, int randomAscii)
        {
            switch (randomAscii)
            {
                case 127:
                case 128:
                    randomAscii = currentCharacter - 1;                                       //One Ascii code smaller
                    break;

                case 129:
                case 130:
                    if (char.IsLower(currentCharacter)) randomAscii = currentCharacter - 32; //If lowercase, convert to uppercase and vice-versa
                    else randomAscii = currentCharacter + 32;
                    break;

                case 131:
                case 132:
                    randomAscii = currentCharacter + 1;                                       //One Ascii code bigger
                    break;
            }

            return randomAscii < 65 ? 126 :                                                 //If over threshold value, roll over
                randomAscii > 126 ? 65 :
                randomAscii;
        }

        /*The method calculates if two characters are next to eachother. 
         * Alphabet starts from ' ' and then (in lower case) a, b, c ... y, z.
         * It uses Ascii codes (32-126) so '{' is a neighbour of 'z'. It also rolls over ('~' neighbours ' ').
         * This also means that in lower-case 'a' neighbours ' ', but in upper-case it does not.
         * Only one step ("Move 1 step in Ascii" OR "change case") is allowed. Therefore 'a' and 'B' are NOT neighbours.
         */

        public static bool Near(char c1, char c2)
        {
            int difference;

            if (AllAsciiCharacters)
            {
                difference = Math.Abs(c1 - c2);
                if (difference == 1) return true;                                           //neighbours
                else if (char.ToLower(c2).Equals(char.ToLower(c1))) return true;            //different case, same letter
                else if ((c1 == 32 && c2 == 126) || (c1 == 126 && c2 == 32)) return true;   //neighbours by rolling over
                return false;
            }

            if (AllowUpperCase)
            {
                if (c1 == ' ') c1 = (char)64;                                              //space is Ascii code 32, convert that
                if (c2 == ' ') c2 = (char)64;

                difference = Math.Abs(c1 - c2);
                if (difference == 1 || difference == 32) return true;
                else if ((c1 == 64 && c2 == 122) || (c1 == 122 && c2 == 64) ||
                         (c1 == 97 && c2 == 90) || (c1 == 90 && c2 == 97)) return true;
                return false;
            }
            if (c1 == ' ') c1 = (char)96;
            if (c2 == ' ') c2 = (char)96;

            difference = Math.Abs(c1 - c2);
            if (difference == 1) return true;
            else if ((c1 == 96 && c2 == 122) || (c1 == 122 && c2 == 96)) return true;
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