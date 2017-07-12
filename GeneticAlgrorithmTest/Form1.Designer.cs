namespace GeneticAlgorithmTest
{
    partial class Form1
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Population = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.DetailTextBox = new System.Windows.Forms.RichTextBox();
            this.BestGuessTextBox = new System.Windows.Forms.TextBox();
            this.CurrentGuessLabel = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.GenerationLabel = new System.Windows.Forms.Label();
            this.FitnessLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ElitePctTextBox = new System.Windows.Forms.TextBox();
            this.ElitePctLabel = new System.Windows.Forms.Label();
            this.AllASCIICheckBox = new System.Windows.Forms.CheckBox();
            this.UpperCaseAndSpacesCheckBox = new System.Windows.Forms.CheckBox();
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
            this.StartBtn.TabIndex = 4;
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
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(190, 49);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Phrase to guess";
            // 
            // Population
            // 
            this.Population.AutoSize = true;
            this.Population.Location = new System.Drawing.Point(50, 109);
            this.Population.Name = "Population";
            this.Population.Size = new System.Drawing.Size(57, 13);
            this.Population.TabIndex = 3;
            this.Population.Text = "Population";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(136, 109);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(69, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Mutation rate";
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
            this.DetailTextBox.TabIndex = 4;
            this.DetailTextBox.TabStop = false;
            this.DetailTextBox.Text = "";
            // 
            // BestGuessTextBox
            // 
            this.BestGuessTextBox.Location = new System.Drawing.Point(40, 212);
            this.BestGuessTextBox.Name = "BestGuessTextBox";
            this.BestGuessTextBox.Size = new System.Drawing.Size(374, 20);
            this.BestGuessTextBox.TabIndex = 5;
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
            this.StopBtn.TabIndex = 4;
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
            // ElitePctTextBox
            // 
            this.ElitePctTextBox.Location = new System.Drawing.Point(222, 125);
            this.ElitePctTextBox.Name = "ElitePctTextBox";
            this.ElitePctTextBox.Size = new System.Drawing.Size(80, 20);
            this.ElitePctTextBox.TabIndex = 3;
            // 
            // ElitePctLabel
            // 
            this.ElitePctLabel.AutoSize = true;
            this.ElitePctLabel.Location = new System.Drawing.Point(220, 109);
            this.ElitePctLabel.Name = "ElitePctLabel";
            this.ElitePctLabel.Size = new System.Drawing.Size(84, 13);
            this.ElitePctLabel.TabIndex = 3;
            this.ElitePctLabel.Text = "Elite percentage";
            // 
            // AllASCIICheckBox
            // 
            this.AllASCIICheckBox.AutoSize = true;
            this.AllASCIICheckBox.Enabled = false;
            this.AllASCIICheckBox.Location = new System.Drawing.Point(223, 164);
            this.AllASCIICheckBox.Name = "AllASCIICheckBox";
            this.AllASCIICheckBox.Size = new System.Drawing.Size(147, 17);
            this.AllASCIICheckBox.TabIndex = 9;
            this.AllASCIICheckBox.Text = "Allow all ASCII characters";
            this.AllASCIICheckBox.UseVisualStyleBackColor = true;
            this.AllASCIICheckBox.CheckedChanged += new System.EventHandler(this.AllASCIICheckBox_CheckedChanged);
            // 
            // UpperCaseAndSpacesCheckBox
            // 
            this.UpperCaseAndSpacesCheckBox.AutoSize = true;
            this.UpperCaseAndSpacesCheckBox.Location = new System.Drawing.Point(40, 164);
            this.UpperCaseAndSpacesCheckBox.Name = "UpperCaseAndSpacesCheckBox";
            this.UpperCaseAndSpacesCheckBox.Size = new System.Drawing.Size(174, 17);
            this.UpperCaseAndSpacesCheckBox.TabIndex = 9;
            this.UpperCaseAndSpacesCheckBox.Text = "Allow spaces and capital letters";
            this.UpperCaseAndSpacesCheckBox.UseVisualStyleBackColor = true;
            this.UpperCaseAndSpacesCheckBox.CheckedChanged += new System.EventHandler(this.UpperCaseAndSpacesCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 419);
            this.Controls.Add(this.UpperCaseAndSpacesCheckBox);
            this.Controls.Add(this.AllASCIICheckBox);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.FitnessLabel);
            this.Controls.Add(this.GenerationLabel);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.BestGuessTextBox);
            this.Controls.Add(this.DetailTextBox);
            this.Controls.Add(this.ElitePctLabel);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Population);
            this.Controls.Add(this.CurrentGuessLabel);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ElitePctTextBox);
            this.Controls.Add(this.MutationRateTextBox);
            this.Controls.Add(this.PopulationTextBox);
            this.Controls.Add(this.PhraseToGuessTextBox);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.TextBox PhraseToGuessTextBox;
        private System.Windows.Forms.TextBox PopulationTextBox;
        private System.Windows.Forms.TextBox MutationRateTextBox;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Population;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label CurrentGuessLabel;
        private System.Windows.Forms.RichTextBox DetailTextBox;
        private System.Windows.Forms.TextBox BestGuessTextBox;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label GenerationLabel;
        private System.Windows.Forms.Label FitnessLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.TextBox ElitePctTextBox;
        private System.Windows.Forms.Label ElitePctLabel;
        private System.Windows.Forms.CheckBox AllASCIICheckBox;
        private System.Windows.Forms.CheckBox UpperCaseAndSpacesCheckBox;
    }
}

