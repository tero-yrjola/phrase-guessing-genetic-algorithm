using System.Windows.Forms;

namespace GeneticAlgorithmTest
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.PhraseToGuessTextBox = new System.Windows.Forms.TextBox();
            this.PopulationTextBox = new System.Windows.Forms.TextBox();
            this.MutationRateTextBox = new System.Windows.Forms.TextBox();
            this.PhraseLabel = new System.Windows.Forms.Label();
            this.PopulationLabel = new System.Windows.Forms.Label();
            this.MutationRateLabel = new System.Windows.Forms.Label();
            this.DetailTextBox = new System.Windows.Forms.RichTextBox();
            this.BestGuessTextBox = new System.Windows.Forms.TextBox();
            this.CurrentGuessLabel = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.GenerationLabel = new System.Windows.Forms.Label();
            this.FitnessLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.EliteRateTextBox = new System.Windows.Forms.TextBox();
            this.EliteRateLabel = new System.Windows.Forms.Label();
            this.AllASCIICheckBox = new System.Windows.Forms.CheckBox();
            this.UpperCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.advancedEvolutionCheckBox = new System.Windows.Forms.CheckBox();
            this.CreatedByLabel2 = new System.Windows.Forms.LinkLabel();
            this.CreatedByLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TitleLabel.Location = new System.Drawing.Point(111, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(238, 20);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Genetic phrase finding algorithm";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(325, 113);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(89, 42);
            this.StartBtn.TabIndex = 7;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // PhraseToGuessTextBox
            // 
            this.PhraseToGuessTextBox.Location = new System.Drawing.Point(40, 65);
            this.PhraseToGuessTextBox.Name = "PhraseToGuessTextBox";
            this.PhraseToGuessTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PhraseToGuessTextBox.Size = new System.Drawing.Size(374, 20);
            this.PhraseToGuessTextBox.TabIndex = 0;
            // 
            // PopulationTextBox
            // 
            this.PopulationTextBox.Location = new System.Drawing.Point(40, 125);
            this.PopulationTextBox.Name = "PopulationTextBox";
            this.PopulationTextBox.Size = new System.Drawing.Size(80, 20);
            this.PopulationTextBox.TabIndex = 1;
            // 
            // MutationRateTextBox
            // 
            this.MutationRateTextBox.Location = new System.Drawing.Point(131, 125);
            this.MutationRateTextBox.Name = "MutationRateTextBox";
            this.MutationRateTextBox.Size = new System.Drawing.Size(80, 20);
            this.MutationRateTextBox.TabIndex = 2;
            // 
            // PhraseLabel
            // 
            this.PhraseLabel.AutoSize = true;
            this.PhraseLabel.Location = new System.Drawing.Point(190, 49);
            this.PhraseLabel.Name = "PhraseLabel";
            this.PhraseLabel.Size = new System.Drawing.Size(83, 13);
            this.PhraseLabel.TabIndex = 3;
            this.PhraseLabel.Text = "Phrase to guess";
            // 
            // PopulationLabel
            // 
            this.PopulationLabel.AutoSize = true;
            this.PopulationLabel.Location = new System.Drawing.Point(50, 109);
            this.PopulationLabel.Name = "PopulationLabel";
            this.PopulationLabel.Size = new System.Drawing.Size(57, 13);
            this.PopulationLabel.TabIndex = 3;
            this.PopulationLabel.Text = "Population";
            // 
            // MutationRateLabel
            // 
            this.MutationRateLabel.AutoSize = true;
            this.MutationRateLabel.Location = new System.Drawing.Point(136, 109);
            this.MutationRateLabel.Name = "MutationRateLabel";
            this.MutationRateLabel.Size = new System.Drawing.Size(69, 13);
            this.MutationRateLabel.TabIndex = 3;
            this.MutationRateLabel.Text = "Mutation rate";
            // 
            // DetailTextBox
            // 
            this.DetailTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.DetailTextBox.HideSelection = false;
            this.DetailTextBox.Location = new System.Drawing.Point(40, 259);
            this.DetailTextBox.Name = "DetailTextBox";
            this.DetailTextBox.ReadOnly = true;
            this.DetailTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.DetailTextBox.Size = new System.Drawing.Size(374, 148);
            this.DetailTextBox.TabIndex = 0;
            this.DetailTextBox.TabStop = false;
            this.DetailTextBox.Text = "";
            // 
            // BestGuessTextBox
            // 
            this.BestGuessTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.BestGuessTextBox.Location = new System.Drawing.Point(40, 212);
            this.BestGuessTextBox.Name = "BestGuessTextBox";
            this.BestGuessTextBox.ReadOnly = true;
            this.BestGuessTextBox.Size = new System.Drawing.Size(374, 20);
            this.BestGuessTextBox.TabIndex = 0;
            this.BestGuessTextBox.TabStop = false;
            // 
            // CurrentGuessLabel
            // 
            this.CurrentGuessLabel.AutoSize = true;
            this.CurrentGuessLabel.Location = new System.Drawing.Point(178, 196);
            this.CurrentGuessLabel.Name = "CurrentGuessLabel";
            this.CurrentGuessLabel.Size = new System.Drawing.Size(95, 13);
            this.CurrentGuessLabel.TabIndex = 3;
            this.CurrentGuessLabel.Text = "Current best guess";
            // 
            // StopBtn
            // 
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(325, 113);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(89, 42);
            this.StopBtn.TabIndex = 7;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Visible = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // GenerationLabel
            // 
            this.GenerationLabel.AutoSize = true;
            this.GenerationLabel.Location = new System.Drawing.Point(37, 243);
            this.GenerationLabel.Name = "GenerationLabel";
            this.GenerationLabel.Size = new System.Drawing.Size(65, 13);
            this.GenerationLabel.TabIndex = 6;
            this.GenerationLabel.Text = "Generation: ";
            // 
            // FitnessLabel
            // 
            this.FitnessLabel.AutoSize = true;
            this.FitnessLabel.Location = new System.Drawing.Point(178, 243);
            this.FitnessLabel.Name = "FitnessLabel";
            this.FitnessLabel.Size = new System.Drawing.Size(69, 13);
            this.FitnessLabel.TabIndex = 7;
            this.FitnessLabel.Text = "Fitness: 0 / 0";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(349, 243);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(42, 13);
            this.TimeLabel.TabIndex = 8;
            this.TimeLabel.Text = "Time: 0";
            // 
            // EliteRateTextBox
            // 
            this.EliteRateTextBox.Location = new System.Drawing.Point(222, 125);
            this.EliteRateTextBox.Name = "EliteRateTextBox";
            this.EliteRateTextBox.Size = new System.Drawing.Size(80, 20);
            this.EliteRateTextBox.TabIndex = 3;
            // 
            // EliteRateLabel
            // 
            this.EliteRateLabel.AutoSize = true;
            this.EliteRateLabel.Location = new System.Drawing.Point(236, 109);
            this.EliteRateLabel.Name = "EliteRateLabel";
            this.EliteRateLabel.Size = new System.Drawing.Size(48, 13);
            this.EliteRateLabel.TabIndex = 3;
            this.EliteRateLabel.Text = "Elite rate";
            // 
            // AllASCIICheckBox
            // 
            this.AllASCIICheckBox.AutoSize = true;
            this.AllASCIICheckBox.Enabled = false;
            this.AllASCIICheckBox.Location = new System.Drawing.Point(267, 170);
            this.AllASCIICheckBox.Name = "AllASCIICheckBox";
            this.AllASCIICheckBox.Size = new System.Drawing.Size(147, 17);
            this.AllASCIICheckBox.TabIndex = 6;
            this.AllASCIICheckBox.Text = "Allow all ASCII characters";
            this.AllASCIICheckBox.UseVisualStyleBackColor = true;
            this.AllASCIICheckBox.CheckedChanged += new System.EventHandler(this.AllASCIICheckBox_CheckedChanged);
            // 
            // UpperCaseCheckBox
            // 
            this.UpperCaseCheckBox.AutoSize = true;
            this.UpperCaseCheckBox.Location = new System.Drawing.Point(123, 170);
            this.UpperCaseCheckBox.Name = "UpperCaseCheckBox";
            this.UpperCaseCheckBox.Size = new System.Drawing.Size(138, 17);
            this.UpperCaseCheckBox.TabIndex = 5;
            this.UpperCaseCheckBox.Text = "Allow upper-case letters";
            this.UpperCaseCheckBox.UseVisualStyleBackColor = true;
            this.UpperCaseCheckBox.CheckedChanged += new System.EventHandler(this.UpperCaseCheckBox_CheckedChanged);
            // 
            // advancedEvolutionCheckBox
            // 
            this.advancedEvolutionCheckBox.AutoSize = true;
            this.advancedEvolutionCheckBox.Location = new System.Drawing.Point(39, 163);
            this.advancedEvolutionCheckBox.MaximumSize = new System.Drawing.Size(80, 0);
            this.advancedEvolutionCheckBox.Name = "advancedEvolutionCheckBox";
            this.advancedEvolutionCheckBox.Size = new System.Drawing.Size(78, 30);
            this.advancedEvolutionCheckBox.TabIndex = 4;
            this.advancedEvolutionCheckBox.Text = "Advanced \r\n Evolution";
            this.advancedEvolutionCheckBox.UseVisualStyleBackColor = true;
            this.advancedEvolutionCheckBox.CheckedChanged += new System.EventHandler(this.advancedEvolutionCheckBox_CheckedChanged);
            // 
            // CreatedByLabel2
            // 
            this.CreatedByLabel2.BackColor = System.Drawing.Color.Transparent;
            this.CreatedByLabel2.CausesValidation = false;
            this.CreatedByLabel2.Font = new System.Drawing.Font("Arial", 7.25F);
            this.CreatedByLabel2.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.CreatedByLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.CreatedByLabel2.Location = new System.Drawing.Point(230, 413);
            this.CreatedByLabel2.Name = "CreatedByLabel2";
            this.CreatedByLabel2.Size = new System.Drawing.Size(36, 13);
            this.CreatedByLabel2.TabIndex = 8;
            this.CreatedByLabel2.Text = "Tero";
            this.CreatedByLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CreatedByLabel2.Click += new System.EventHandler(this.OpenLink_Event);
            // 
            // CreatedByLabel1
            // 
            this.CreatedByLabel1.AutoSize = true;
            this.CreatedByLabel1.BackColor = System.Drawing.Color.Transparent;
            this.CreatedByLabel1.Font = new System.Drawing.Font("Arial", 7.25F);
            this.CreatedByLabel1.ForeColor = System.Drawing.Color.Black;
            this.CreatedByLabel1.Location = new System.Drawing.Point(180, 413);
            this.CreatedByLabel1.Name = "CreatedByLabel1";
            this.CreatedByLabel1.Size = new System.Drawing.Size(58, 13);
            this.CreatedByLabel1.TabIndex = 9;
            this.CreatedByLabel1.Text = "Created by";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 433);
            this.Controls.Add(this.CreatedByLabel1);
            this.Controls.Add(this.CreatedByLabel2);
            this.Controls.Add(this.advancedEvolutionCheckBox);
            this.Controls.Add(this.UpperCaseCheckBox);
            this.Controls.Add(this.AllASCIICheckBox);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.FitnessLabel);
            this.Controls.Add(this.GenerationLabel);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.BestGuessTextBox);
            this.Controls.Add(this.DetailTextBox);
            this.Controls.Add(this.EliteRateLabel);
            this.Controls.Add(this.MutationRateLabel);
            this.Controls.Add(this.PopulationLabel);
            this.Controls.Add(this.CurrentGuessLabel);
            this.Controls.Add(this.PhraseLabel);
            this.Controls.Add(this.EliteRateTextBox);
            this.Controls.Add(this.MutationRateTextBox);
            this.Controls.Add(this.PopulationTextBox);
            this.Controls.Add(this.PhraseToGuessTextBox);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Window";
            this.Text = "Genetic phrase search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox PhraseToGuessTextBox;
        private System.Windows.Forms.TextBox PopulationTextBox;
        private System.Windows.Forms.TextBox MutationRateTextBox;
        private System.Windows.Forms.Label PhraseLabel;
        private System.Windows.Forms.Label PopulationLabel;
        private System.Windows.Forms.Label MutationRateLabel;
        private System.Windows.Forms.Label CurrentGuessLabel;
        private System.Windows.Forms.RichTextBox DetailTextBox;
        private System.Windows.Forms.TextBox BestGuessTextBox;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label GenerationLabel;
        private System.Windows.Forms.Label FitnessLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.TextBox EliteRateTextBox;
        private System.Windows.Forms.Label EliteRateLabel;
        private System.Windows.Forms.CheckBox AllASCIICheckBox;
        private System.Windows.Forms.CheckBox UpperCaseCheckBox;
        private System.Windows.Forms.CheckBox advancedEvolutionCheckBox;
        private System.Windows.Forms.LinkLabel CreatedByLabel2;
        private Label CreatedByLabel1;
    }
}

