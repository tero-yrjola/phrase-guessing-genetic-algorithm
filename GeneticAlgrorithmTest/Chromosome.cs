using GeneticAlgorithmTest;

namespace GeneticAlgorithmTest
{
    public class Chromosome
    {
        private string genes;
        private int fitness;

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
        public int GetFitness()
        {
            return fitness;
        }

        public string GetGenes()
        {
            return genes;
        }

        public int CalculateFitness(string phraseToGuess)
        {
            int matchingLetters = 0;

            for (int i = 0; i < phraseToGuess.Length; i++)
            {
                if (genes[i] == phraseToGuess[i]) matchingLetters++;
            }

            fitness = matchingLetters;

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