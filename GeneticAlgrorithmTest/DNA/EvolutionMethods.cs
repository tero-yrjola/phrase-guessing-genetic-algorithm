using System;

namespace GeneticAlgorithmTest
{
    public class EvolutionMethods
    {
        private static readonly Random rng = new Random();

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
                        newGene += Helpers.ReturnRandomChar();
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

        public static Chromosome[] MutateDnaAdvanced(decimal mutationRate, Chromosome[] chromosomes)
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
                        newGene += Helpers.ReturnGeneticallyCloseChar(chromosome.GetGenes()[i]);
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
}