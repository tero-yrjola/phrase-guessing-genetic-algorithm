using System;

namespace GeneticAlgrorithmTest
{
    public class GeneticAlgorithm
    {
        private string phraseToGuess;
        private int value2;
        private decimal value3;

        public GeneticAlgorithm(string phraseToGuess, string value2, string value3)
        {
            this.phraseToGuess = phraseToGuess;
            this.value2 = Convert.ToInt32(value2);
            this.value3 = Convert.ToDecimal(value3);

            //TODO the algorithm itself lol
        }
    }
}