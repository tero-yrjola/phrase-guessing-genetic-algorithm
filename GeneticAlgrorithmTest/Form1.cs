using System;
using System.Windows.Forms;
using static GeneticAlgorithmTest.Helpers;
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
            set { PopulationTextBox.Text = ReturnValidPopulation(value); }
            get { return PopulationTextBox.Text; }
        }

        private string mutationRate
        {
            set { MutationRateTextBox.Text = ReturnValidPercentage(value); }
            get { return MutationRateTextBox.Text; }
        }

        private string elitePct
        {
            set { ElitePctTextBox.Text = ReturnValidPercentage(value); }
            get { return ElitePctTextBox.Text; }
        }

        public const string DefaultPopulation = "1000";
        public const string DefaultPercentage = "0,1";

        public bool AllowUpperCaseAndSpaces;
        public bool AllowAllAsciiCharacters;

        public Form1()
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

        private void StartBtn_Click(object sender, EventArgs e)
        {
            ResetTimer();

            try
            {
                Helpers.AllowUpperCaseAndSpaces = AllowUpperCaseAndSpaces;
                AllASCIICharacters = AllowAllAsciiCharacters;

                phraseToGuess = CheckPhraseLegitimacy(PhraseToGuessTextBox.Text);
                population = PopulationTextBox.Text;
                mutationRate = MutationRateTextBox.Text;
                elitePct = ElitePctTextBox.Text;

                GeneticAlgorithm.cancellationToken = false;
                Output(GetStartOutputString());
                SetUpLabels();
                SwapBetweenStartAndStop();

                GeneticAlgorithm algorithm = new GeneticAlgorithm(phraseToGuess, population, mutationRate, elitePct, this);

                algorithm.Run();
            }
            catch (InputFieldValueException ex)
            {
                Output(ex.Message);
            }
        }

        private string GetStartOutputString()
        {
            string s = $"Starting with following values: \nPopulation = {population}, mutation rate = {(int)(Numeric(mutationRate) * 100)}% " +
                       $"and elite percentage = {(int)(Numeric(elitePct) * 100)}%,\nSyntax = ";

            if (!AllowUpperCaseAndSpaces) s += "only lower-case letters allowed.";
            else if (AllowAllAsciiCharacters) s += "all Ascii-characters allowed.";
            else s += "only alphabets and spaces allowed.";

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
            var form = ActiveForm as Form1;
            if (form != null) form.DetailTextBox.AppendText(s + "\n");
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
            ElitePctTextBox.Enabled = enabled;
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

        private void UpperCaseAndSpacesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AllowUpperCaseAndSpaces = UpperCaseAndSpacesCheckBox.Checked;
            if (AllowUpperCaseAndSpaces) AllASCIICheckBox.Enabled = true;
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
    }
}
