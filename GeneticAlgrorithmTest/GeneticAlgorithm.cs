using System;
using System.Threading.Tasks;
using static GeneticAlgorithmTest.Helpers;

namespace GeneticAlgorithmTest
{
    public class GeneticAlgorithm
    {
        private readonly string phraseToGuess;
        private readonly int population;
        private readonly int chromosomeLength;
        private readonly decimal mutationRate;
        private readonly decimal eliteRate;
        private readonly bool advancedEvolution;
        private int currentGeneration;
        private DNA dna;

        private Window form;

        public int maximumGeneration = 5000;
        public static bool cancellationToken;

        public GeneticAlgorithm(string phraseToGuess, string pop, string mutRate, string eliteRate, bool advancedEvolution, Window form)
        {
            this.phraseToGuess = phraseToGuess;
            this.chromosomeLength = phraseToGuess.Length;
            this.population = Convert.ToInt32(pop);
            this.mutationRate = Numeric(mutRate);
            this.eliteRate = Numeric(eliteRate);
            this.advancedEvolution = advancedEvolution;
            this.form = form;
            }

        public async void Run()
        {
            dna = new DNA(chromosomeLength, population);

            for (int currentGen = 0; currentGen < maximumGeneration; currentGen++)
            {
                if (!advancedEvolution) dna.CalculateFitnessesFor(phraseToGuess);
                else dna.CalculateAdvancedFitnessesFor(phraseToGuess);

                if (cancellationToken) break;
                dna.SelectionAndCrossOver(eliteRate);
                
                form.UpdateFormValues(dna.GetBestGuess());

                if (!advancedEvolution) dna.Mutation(mutationRate);
                else dna.AdvancedMutation(mutationRate, currentGeneration);

                if (dna.GetBestGuess().GetFitness() == phraseToGuess.Length)
                {
                    Window.Output($"Match for '{phraseToGuess}' found in generation {currentGen+1}!\nExecuting stopped.\n");
                    break;
                }

                currentGeneration++;
                await Task.Delay(10);
            }

            form.StopExecuting();
        }
    }
}