using System;
using System.Linq;
using GeneticAlgorithmTest;
using MoreLinq;

namespace GeneticAlgorithmTest
{
    public class DNA
    {
        private Chromosome[] chromosomes;

        private readonly int chromosomeLength;
        private readonly int population;

        private Chromosome bestGuess;

        public decimal ElitePercentage = 0.2m;
        public DNA(int length, int pop)
        {
            chromosomeLength = length;
            chromosomes = new Chromosome[pop];
            population = pop;

            PopulateChromosomes();
        }

        public void CalculateFitnessesFor(string phraseToGuess)
        {
            foreach (Chromosome chromosome in chromosomes)
            {
                chromosome.CalculateFitness(phraseToGuess);
            }
        }

        public Chromosome GetBestGuess()
        {
            return bestGuess;
        }

        private void PopulateChromosomes()
        {
            for (int i = 0; i < chromosomes.Length; i++)
            {
                chromosomes[i] = GenerateChromosomeGenes(new Chromosome());
            }
        }

        private Chromosome GenerateChromosomeGenes(Chromosome chromosome)
        {
            chromosome.Generate(chromosomeLength);
            return chromosome;
        }

        public void SelectionAndCrossOver()
        {
            var numberOfElites = (int) (population * ElitePercentage + 0.5m);
            var elites = chromosomes.OrderByDescending(c => c.GetFitness()).Take(numberOfElites).ToArray();

            bestGuess = elites[0];

            var crossOverChildren = Helpers.CrossOverElites(elites, population - numberOfElites);

            chromosomes = elites.Concat(crossOverChildren).ToArray();
        }

        public void Mutation(decimal mutationRate)
        {
            chromosomes = Helpers.MutateDna(mutationRate, chromosomes);
        }
    }
}