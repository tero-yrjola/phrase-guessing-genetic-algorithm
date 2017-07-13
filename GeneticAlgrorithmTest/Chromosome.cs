using System;

namespace GeneticAlgorithmTest
{
    public class Chromosome
    {
        private string genes;
        private decimal fitness;

        public Chromosome()
        {
            this.genes = "";
            this.fitness = 0;
        }

        public Chromosome(string genes)
        {
            this.genes = genes;
            this.fitness = 0;
        }
        public decimal GetFitness()
        {
            return fitness;
        }

        public string GetGenes()
        {
            return genes;
        }

        public decimal CalculateFitness(string phraseToGuess)
        {
            int matchingLetters = 0;

            for (int i = 0; i < phraseToGuess.Length; i++)
            {
                if (genes[i] == phraseToGuess[i]) matchingLetters++;
            }

            fitness = matchingLetters;

            return fitness;
        }
        public decimal CalculateAdvancedFitness(string phraseToGuess)
        {
            decimal matchingScore = 0;

            for (int i = 0; i < phraseToGuess.Length; i++)
            {
                if (genes[i] == phraseToGuess[i]) matchingScore++;
                else if (Helpers.IsNearAsciiChar(genes[i], phraseToGuess[i])) matchingScore += 0.5m;
            }

            fitness = matchingScore;

            return fitness;
        }
        public void Generate(int chromosomeLength)
        {
            var newGenes = "";
            for (int i = 0; i < chromosomeLength; i++)
            {
                newGenes += Helpers.ReturnRandomChar();
            }

            genes = newGenes;
        }

        public void Mutate(string newGene)
        {
            genes = newGene;
        }
    }
}