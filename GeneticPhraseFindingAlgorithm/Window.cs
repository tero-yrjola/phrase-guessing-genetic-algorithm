using System;
using System.Windows.Forms;
using static GeneticAlgorithmTest.Helpers;
using Timer = System.Windows.Forms.Timer;

namespace GeneticAlgorithmTest
{
    public partial class Window : Form
    {
        private int currentGen;
        private Chromosome bestGuess;

        private Timer timer;
        private int time;

        private string phraseToGuess
        {
            set { PhraseToGuessTextBox.Text = ReturnValidPhrase(value); }
            get { return PhraseToGuessTextBox.Text; }
        }
        private string population
        {
            set { PopulationTextBox.Text = ReturnValidPopulation(value); }
            get { return PopulationTextBox.Text; }
        }

        private string mutationRate
        {
            set { MutationRateTextBox.Text = ReturnValidPercentage(value); }
            get { return MutationRateTextBox.Text; }
        }

        private string eliteRate
        {
            set { EliteRateTextBox.Text = ReturnValidPercentage(value); }
            get { return EliteRateTextBox.Text; }
        }

        public const string DefaultPopulation = "1000";
        public const string DefaultPercentage = "0,05";
        public const string DefaultPhrase = "this is a default phrase";

        public bool AllowUpperCase;
        public bool AllowAllAsciiCharacters;
        public bool AdvancedEvolution;

        public Window()
        {
            InitializeComponent();
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            AcceptButton = StartBtn;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Enabled = false;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ResetTimer();

            try
            {
                Helpers.AllowUpperCase = AllowUpperCase;
                Helpers.AllAsciiCharacters = AllowAllAsciiCharacters;

                phraseToGuess = ReturnValidPhrase(PhraseToGuessTextBox.Text);
                population = PopulationTextBox.Text;
                mutationRate = MutationRateTextBox.Text;
                eliteRate = EliteRateTextBox.Text;

                GeneticAlgorithm.cancellationToken = false;
                Output(GetStartOutputString());
                SetUpLabels();
                SwapBetweenStartAndStop();

                GeneticAlgorithm algorithm = new GeneticAlgorithm(phraseToGuess, population, mutationRate, eliteRate, AdvancedEvolution, this);

                algorithm.Run();
            }
            catch (InputFieldValueException ex)
            {
                Output(ex.Message);
            }
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
            FitnessLabel.Text = $"Fitness: {bestGuess?.GetFitness() ?? 0} / {phraseToGuess?.Length}";
        }

        private void DrawGeneration()
        {
            GenerationLabel.Text = $"Generation: {currentGen}";
        }

        private void DrawBestGuess()
        {
            BestGuessTextBox.Text = bestGuess.GetGenes();
        }

        private string GetStartOutputString()
        {
            string s = $"Starting with following values: \nPopulation = {population}, mutation rate = {Numeric(mutationRate)} " +
                       $"and elite rate = {Numeric(eliteRate)},\nSyntax = ";

            if (!AllowUpperCase) s += "only lower-case letters allowed.";
            else if (AllowAllAsciiCharacters) s += "all Ascii-characters allowed.";
            else s += "only alphabets allowed.";

            return s;
        }

        private void SetUpLabels()
        {
            timer.Enabled = true;
            DrawFitness();
            DrawGeneration();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopExecuting();
            Output("Stopped.\n");
        }

        public void StopExecuting()
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

            DrawBestGuess();
            DrawFitness();
            DrawGeneration();
        }

        public static void Output(string s)
        {
            var form = ActiveForm as Window;
            form?.DetailTextBox.AppendText(s + "\n");
        }

        private void SwapBetweenStartAndStop()
        {
            SwapStartAndStopButtons();
        }

        private void SwapFieldAccessibility(bool enabled)
        {
            PhraseToGuessTextBox.Enabled = enabled;
            PopulationTextBox.Enabled = enabled;
            MutationRateTextBox.Enabled = enabled;
            EliteRateTextBox.Enabled = enabled;
            UpperCaseCheckBox.Enabled = enabled;
            AllASCIICheckBox.Enabled = UpperCaseCheckBox.Checked && enabled;
            advancedEvolutionCheckBox.Enabled = enabled;
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

        private void UpperCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AllowUpperCase = UpperCaseCheckBox.Checked;

            if (AllowUpperCase) AllASCIICheckBox.Enabled = true;
            else
            {
                AllASCIICheckBox.Checked = false;
                AllASCIICheckBox.Enabled = false;
            }
        }

        private void AllASCIICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AllowAllAsciiCharacters = AllASCIICheckBox.Checked;
        }

        private void advancedEvolutionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AdvancedEvolution = advancedEvolutionCheckBox.Checked;
        }

        private void OpenLink_Event(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/tero-yrjola");
            }
            catch (Exception ex) { Output("Whoops, something just broke...\n" + ex.StackTrace); }
        }
    }
}
