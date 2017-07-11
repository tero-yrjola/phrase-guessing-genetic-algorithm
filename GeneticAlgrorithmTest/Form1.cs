using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgrorithmTest
{
    public partial class Form1 : Form
    {
        private string phraseToGuess;

        private string value2
        {
            set { Value2.Text = Helpers.ReturnValidField2Value(value); }
            get { return Value2.Text; }
        }

        private string value3
        {
            set { Value3.Text = Helpers.ReturnValidField3Value(value); }
            get { return Value3.Text; }
        }

        public const string DefaultValue2 = "10";
        public const string DefaultValue3 = "10";

        public Form1()
        {
            InitializeComponent();
        }

        private void PhraseToGuessTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                phraseToGuess = Helpers.CheckPhraseLegitimacy(PhraseToGuessTextBox.Text);
                value2 = Value2.Text;
                value3 = Value3.Text;

                Output($"Starting with values {value2} and {value3}");

                SwapBetweenStartAndStop();

                GeneticAlgorithm algorithm = new GeneticAlgorithm(phraseToGuess, value2, value3);
            }
            catch (Exception)
            {
                Output("Check your values fool!");
            }
        }

        private void Output(string s)
        {
            DetailTextBox.Text += s + "\n";
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            SwapBetweenStartAndStop();
            Output("Stopped!");
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
