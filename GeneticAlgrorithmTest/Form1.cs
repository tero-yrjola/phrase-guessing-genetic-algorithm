using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneticAlgorithmTest;
using Timer = System.Windows.Forms.Timer;

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
            set { Value3.Text = Helpers.ReturnValidPercentage(value); }
            get { return Value3.Text; }
        }

        private string elitePct
        {
            set { ElitePctTextBox.Text = Helpers.ReturnValidPercentage(value); }
            get { return ElitePctTextBox.Text; }
        }

        public const string DefaultPopulation = "1000";
        public const string DefaultPercentage = "0,1";

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

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ResetTimer();

            try
            {
                phraseToGuess = Helpers.CheckPhraseLegitimacy(PhraseToGuessTextBox.Text);
                population = Value2.Text;
                mutationRate = Value3.Text;
                elitePct = ElitePctTextBox.Text;
            }
            catch (InputFieldValueException ex)
            {
                Output(ex.Message);
            }

            Output($"Starting with values {population}, {mutationRate} and {elitePct}.");

            SetUpLabels();

            GeneticAlgorithm algorithm = new GeneticAlgorithm(phraseToGuess, population, mutationRate, elitePct, this);

            GeneticAlgorithm.cancellationToken = false;
            SwapBetweenStartAndStop();

            algorithm.Run();
        }

        private void SetUpLabels()
        {
            timer.Enabled = true;
            DrawFitness();
            DrawGeneration();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Output("Stopping.");
            StopExcecuting();
        }

        public void StopExcecuting()
        {
            GeneticAlgorithm.cancellationToken = true;

            timer.Enabled = false;
            currentGen = 0;
            bestGuess = null;

            SwapBetweenStartAndStop();
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

        public static void Output(string s)
        {
            var form = Form.ActiveForm as Form1;
            if (form != null) form.DetailTextBox.Text += s + "\n";
        }

        private void SwapBetweenStartAndStop()
        {
            SwapStartAndStopButtons();
        }

        private void SwapFieldAccessibility(bool enabled)
        {
            PhraseToGuessTextBox.Enabled = enabled;
            Value2.Enabled = enabled;
            Value3.Enabled = enabled;
        }

        private void SwapStartAndStopButtons()
        {
            if (GeneticAlgorithm.cancellationToken)
            {
                StartBtn.Visible = true;
                StartBtn.Enabled = true;

                StopBtn.Visible = false;
                StopBtn.Enabled = false;

                SwapFieldAccessibility(true);
            }
            else
            {
                StartBtn.Visible = false;
                StartBtn.Enabled = false;

                StopBtn.Visible = true;
                StopBtn.Enabled = true;

                SwapFieldAccessibility(false);
            }


        }
    }
}
