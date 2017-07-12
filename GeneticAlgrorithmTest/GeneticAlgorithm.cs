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
        private DNA dna;

        private Form1 form;

        public int maximumGeneration = 5000;
        public static Boolean cancellationToken;
        public GeneticAlgorithm(string phraseToGuess, string pop, string mutRate, string elitePct, Form1 form)
        {
            this.phraseToGuess = phraseToGuess;
            this.chromosomeLength = phraseToGuess.Length;
            this.population = Convert.ToInt32(pop);
            this.mutationRate = Numeric(mutRate);
            this.elitePct = Numeric(elitePct);
            this.form = form;
        }

        public async void Run()
        {
            dna = new DNA(chromosomeLength, population);

            for (int i = 0; i < maximumGeneration; i++)
            {
                if (cancellationToken) break;
                dna.SelectionAndCrossOver(elitePct);

                dna.CalculateFitnessesFor(phraseToGuess);

                form.UpdateFormValues(dna.GetBestGuess());

                dna.Mutation(mutationRate);

                if (dna.GetBestGuess().GetFitness() == phraseToGuess.Length)
                {
                    Form1.Output($"Match found! Stopping excecution.\n");
                    break;
                }

                await Task.Delay(10);
            }

            form.StopExcecuting();
        }
    }
}