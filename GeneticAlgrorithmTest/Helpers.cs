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
                return string.IsNullOrWhiteSpace(valueString) ? DefaultPopulation :
                    Numeric(valueString) <= 0 || Numeric(valueString) >= 1000001
                        ? throw new FormatException() : valueString;
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
                return string.IsNullOrWhiteSpace(valueString) ? DefaultPercentage :
                    Numeric(valueString) <= 0 || Numeric(valueString) >= 1
                        ? throw new FormatException() : valueString;
            }
            catch (FormatException)
            {
                throw new InputFieldValueException("Mutation rate / elite percentage has to be a decimal between 0 and 1.");
            }
        }

        public static string CheckPhraseLegitimacy(string s)
        {
            if (AllowUpperCase)
            {
                if (AllAsciiCharacters)
                {
                    if (s.Any(ch => ch < 127)) return s;
                }
                else
                {
                    if (s.Any(ch => char.IsLetter(ch) || ch == ' ')) return s;
                }
            }
            else
            {
                if (s.Any(char.IsLower)) return s;
            }

            throw new InputFieldValueException("Phrase invalid!");
        }

        public static char ReturnRandomChar()
        {
            if (AllAsciiCharacters) return (char)rng.Next(32, 127);

            int randomAlphabetInAscii = (randomAlphabetInAscii = rng.Next(64, 114)) > 90 //Skip over 6 ASCII-characters that aren't alphabets
                ? randomAlphabetInAscii + 6
                : randomAlphabetInAscii == 64 ? ' ' : randomAlphabetInAscii;

            if (AllowUpperCase) return (char)randomAlphabetInAscii;

            return char.ToLower((char)randomAlphabetInAscii);

        }

        public static decimal Numeric(object T)
        {
            return Convert.ToDecimal(T.ToString());
        }

        public static Chromosome[] CrossOverElites(Chromosome[] elites, int amount)
        {
            Chromosome[] children = new Chromosome[amount];

            for (int i = 0; i < amount; i++)
            {
                children[i] = CrossOver(elites[rng.Next(0, elites.Length)], elites[rng.Next(0, elites.Length)]);
            }

            return children;
        }

        private static Chromosome CrossOver(Chromosome chromOne, Chromosome chromTwo)
        {
            string chromOneString = chromOne.GetGenes();
            string chromTwoString = chromTwo.GetGenes();

            string returnChromosomeString = "";
            for (int i = 0; i < chromOneString.Length; i++)
            {
                if (rng.Next(0, 2) == 1) returnChromosomeString += chromOneString[i];
                else returnChromosomeString += chromTwoString[i];
            }

            return new Chromosome(returnChromosomeString);
        }

        public static Chromosome[] MutateDna(decimal mutationRate, Chromosome[] chromosomes)
        {
            string newGene = "";
            bool needToMutate = false;
            foreach (Chromosome chromosome in chromosomes)
            {
                for (int i = 0; i < chromosome.GetGenes().Length; i++)
                {
                    if (rng.Next(0, 100) > mutationRate * 100) newGene += chromosome.GetGenes()[i];
                    else
                    {
                        needToMutate = true;
                        newGene += ReturnRandomChar();
                    }
                }
                if (needToMutate)
                {
                    chromosome.Mutate(newGene);
                    needToMutate = false;
                }
                newGene = "";
            }
            return chromosomes;
        }
    }

    public class InputFieldValueException : Exception
    {
        public InputFieldValueException(string message) : base(message)
        {
        }
    }
}