using System;
using System.Linq;
using static GeneticAlgorithmTest.EvolutionMethods;

namespace GeneticAlgorithmTest
{
    public class DNA
    {
        private Chromosome[] chromosomes;

        private readonly int chromosomeLength;
        private readonly int population;

        private Chromosome bestGuess;
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

            chromosomes = chromosomes.OrderByDescending(x => x.GetFitness()).ToArray();
        }

        public void CalculateAdvancedFitnessesFor(string phraseToGuess)
        {
            foreach (Chromosome chromosome in chromosomes)
            {
                chromosome.CalculateAdvancedFitness(phraseToGuess);
            }

            chromosomes = chromosomes.OrderByDescending(x => x.GetFitness()).ToArray();
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

        public void SelectionAndCrossOver(decimal eliteRate)
        {
            var numberOfElites = (int)(population * eliteRate + 0.5m);
            var elites = chromosomes.Take(numberOfElites).ToArray();

            Chromosome[] crossOverChildren;

            try
            {
                
                crossOverChildren = CrossOverElites(elites, population - numberOfElites);
            }
            catch (IndexOutOfRangeException ex)
            {
                crossOverChildren = chromosomes;

                bestGuess = chromosomes[0];
            }
            chromosomes = elites.Concat(crossOverChildren).ToArray();

            bestGuess = chromosomes[0];
        }
    

    public void Mutation(decimal mutationRate)
    {
        chromosomes = MutateDna(mutationRate, chromosomes);
    }

    public void AdvancedMutation(decimal mutationRate, int currentGeneration)
    {
        chromosomes = MutateDnaAdvanced(mutationRate, currentGeneration, chromosomes);
    }
}
}