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
        }

        public void CalculateAdvancedFitnessesFor(string phraseToGuess)
        {
            foreach (Chromosome chromosome in chromosomes)
            {
                chromosome.CalculateAdvancedFitness(phraseToGuess);
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

        public void SelectionAndCrossOver(decimal elitePct)
        {
            var numberOfElites = (int)(population * elitePct + 0.5m);
            var elites = chromosomes.OrderByDescending(c => c.GetFitness()).Take(numberOfElites).ToArray();

            bestGuess = elites[0];

            var crossOverChildren = CrossOverElites(elites, population - numberOfElites);

            chromosomes = elites.Concat(crossOverChildren).ToArray();
        }

        public void Mutation(decimal mutationRate)
        {
            chromosomes = MutateDna(mutationRate, chromosomes);
        }

        public void AdvancedMutation(decimal mutationRate)
        {
            chromosomes = MutateDnaAdvanced(mutationRate, chromosomes);
        }
    }
}