using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using GeneticAlgorithmTest;
using static GeneticAlgorithmTest.Form1;

namespace GeneticAlgorithmTest
{

    public class Helpers
    {
        private static readonly Random rng = new Random();
        public static string ReturnValidPopulation(string valueString)
        {
            try
            {
                return string.IsNullOrWhiteSpace(valueString) ? DefaultPopulation :
                    Convert.ToInt32(valueString) <= 0 || Convert.ToInt32(valueString) >= 100
                        ? DefaultPopulation : valueString;
            }
            catch (FormatException ex)
            {
                throw new InputFieldValueException("Population has to be an integer between 0 and 100.");
            }
        }

        public static string ReturnValidMutationRate(string valueString)
        {
            valueString = valueString.Replace('.', ',');

            try
            {
                return string.IsNullOrWhiteSpace(valueString) ? DefaultMutationRate :
                    Convert.ToDecimal(valueString) <= 0 || Convert.ToDecimal(valueString) >= 100
                        ? DefaultMutationRate : valueString;
            }
            catch (FormatException ex)
            {
                throw new InputFieldValueException("Mutation rate has to be a decimal between 0 and 100.");
            }
        }

        public static string CheckPhraseLegitimacy(string s)
        {
            if (s.Any(ch => char.IsLetter(ch) || ch == ' ')) return s;

            throw new InputFieldValueException("Phrase invalid!");
        }

        public static char ReturnRandomChar()
        {
            int randomAlphabetInAscii = (randomAlphabetInAscii = rng.Next(65, 114)) > 90
                ? randomAlphabetInAscii + 6
                : randomAlphabetInAscii;

            return (char)randomAlphabetInAscii;
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

            foreach (Chromosome chromosome in chromosomes)
            {
                for (int i = 0; i < chromosome.GetGenes().Length; i++)
                {
                    if (rng.Next(0, 100) > mutationRate * 100) newGene += chromosome.GetGenes()[i];
                    else newGene += ReturnRandomChar();
                }

                chromosome.Mutate(newGene);
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