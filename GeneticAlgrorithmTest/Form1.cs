using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgorithmTest;

namespace GeneticAlgorithmTest
{
    public partial class Form1 : Form
    {
        private string phraseToGuess;
        private int currentGen;
        private Chromosome bestGuess;

        private Timer timer;
        private int time;

        private string population
        {
            set { Value2.Text = Helpers.ReturnValidPopulation(value); }
            get { return Value2.Text; }
        }

        private string mutationRate
        {
            set { Value3.Text = Helpers.ReturnValidMutationRate(value); }
            get { return Value3.Text; }
        }

        public const string DefaultPopulation = "50";
        public const string DefaultMutationRate = "0,01";

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Enabled = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            time++;
            DrawTimer();
        }

        private void DrawTimer()
        {
            TimeLabel.Text = $"Time: {time}";
        }

        private void DrawFitness()
        {
            FitnessLabel.Text = $"Fitness: {bestGuess?.GetFitness() ?? 0} / {phraseToGuess.Length}";
        }

        private void DrawGeneration()
        {
            GenerationLabel.Text = $"Generation: {currentGen}";
        }

        private void DrawBestGuess()
        {
            BestGuessTextBox.Text = bestGuess.GetGenes();
        }

        private void PhraseToGuessTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ResetTimer();
            try
            {
                phraseToGuess = Helpers.CheckPhraseLegitimacy(PhraseToGuessTextBox.Text);
                population = Value2.Text;
                mutationRate = Value3.Text;

                Output($"Starting with values {population} and {mutationRate}");

                SwapBetweenStartAndStop();

                SetUpLabels();

                GeneticAlgorithm algorithm = new GeneticAlgorithm(phraseToGuess, population, mutationRate, this);

                algorithm.Run();
            }
            catch (InputFieldValueException ex)
            {
                Output(ex.Message);
            }
        }

        private void SetUpLabels()
        {
                timer.Enabled = true;
                DrawFitness();
                DrawGeneration();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            currentGen = 0;
            bestGuess = null;
            
            SwapBetweenStartAndStop();
            Output("Stopped!");
        }

        private void ResetTimer()
        {
            time = 0;
            DrawTimer();
        }

        public void UpdateFormValues(Chromosome bestChromosome)
        {
            bestGuess = bestChromosome;
            currentGen++;

            var form = Form.ActiveForm as Form1;
            if (form != null)
            {
                DrawBestGuess();
                DrawFitness();
                DrawGeneration();
            }
        }

        private static void Output(string s)
        {
            var form = Form.ActiveForm as Form1;
            if (form != null) form.DetailTextBox.Text += s + "\n";
        }

        private void SwapBetweenStartAndStop()
        {
            SwapStartAndStopButtons();
            SwapFieldAccessibility();
        }

        private void SwapFieldAccessibility()
        {
            PhraseToGuessTextBox.Enabled = !PhraseToGuessTextBox.Enabled;
            Value2.Enabled = !Value2.Enabled;
            Value3.Enabled = !Value3.Enabled;
        }

        private void SwapStartAndStopButtons()
        {
            StartBtn.Visible = !StartBtn.Visible;
            StartBtn.Enabled = !StartBtn.Enabled;

            StopBtn.Visible = !StopBtn.Visible;
            StopBtn.Enabled = !StopBtn.Enabled;
        }
    }
}
