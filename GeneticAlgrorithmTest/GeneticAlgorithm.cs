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
        private readonly decimal elitePct;
        private readonly bool advancedEvolution;
        private int currentGeneration;
        private DNA dna;

        private Form1 form;

        public int maximumGeneration = 5000;
        public static bool cancellationToken;

        public GeneticAlgorithm(string phraseToGuess, string pop, string mutRate, string elitePct, bool advancedEvolution, Form1 form)
        {
            this.phraseToGuess = phraseToGuess;
            this.chromosomeLength = phraseToGuess.Length;
            this.population = Convert.ToInt32(pop);
            this.mutationRate = Numeric(mutRate);
            this.elitePct = Numeric(elitePct);
            this.advancedEvolution = advancedEvolution;
            this.form = form;
            }

        public async void Run()
        {
            dna = new DNA(chromosomeLength, population);

            for (int i = 0; i < maximumGeneration; i++)
            {
                if (!advancedEvolution) dna.CalculateFitnessesFor(phraseToGuess);
                else dna.CalculateAdvancedFitnessesFor(phraseToGuess);

                if (cancellationToken) break;
                dna.SelectionAndCrossOver(elitePct);
                
                form.UpdateFormValues(dna.GetBestGuess());

                if (!advancedEvolution) dna.Mutation(mutationRate);
                else dna.AdvancedMutation(mutationRate, currentGeneration);

                if (dna.GetBestGuess().GetFitness() == phraseToGuess.Length)
                {
                    Form1.Output($"Match for '{phraseToGuess}' found! Stopping execution.\n");
                    break;
                }

                currentGeneration++;
                await Task.Delay(10);
            }

            form.StopExecuting();
        }
    }
}