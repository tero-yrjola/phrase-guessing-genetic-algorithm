using System;
using System.Threading.Tasks;
using GeneticAlgorithmTest;

namespace GeneticAlgorithmTest
{
    public class GeneticAlgorithm
    {
        private string phraseToGuess;
        private int population;
        private decimal mutationRate;
        private int chromosomeLength;
        private DNA dna;

        private Form1 form;

        public GeneticAlgorithm(string phraseToGuess, string pop, string mutRate, Form1 form)
        {
            this.phraseToGuess = phraseToGuess;
            this.chromosomeLength = phraseToGuess.Length;
            this.population = Convert.ToInt32(pop);
            this.mutationRate = Convert.ToDecimal(mutRate);
            this.form = form;
        }

        public async void Run()
        {
            dna = new DNA(chromosomeLength, population);

            for (int i = 0; i < 20; i++)
            {
                dna.SelectionAndCrossOver();

                dna.CalculateFitnessesFor(phraseToGuess);

                form.UpdateFormValues(dna.GetBestGuess());

                dna.Mutation(mutationRate);

                await Task.Delay(50);
            }
        }
    }
}