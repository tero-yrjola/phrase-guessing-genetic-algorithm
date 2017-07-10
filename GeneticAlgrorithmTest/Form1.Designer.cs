namespace GeneticAlgrorithmTest
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
            this.Value2 = new System.Windows.Forms.TextBox();
            this.Value3 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.DetailTextBox = new System.Windows.Forms.RichTextBox();
            this.BestGuessTextBox = new System.Windows.Forms.TextBox();
            this.CurrentGuessLabel = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TitleLabel.Location = new System.Drawing.Point(111, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(223, 20);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Genetic word finding algorithm";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(325, 113);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(89, 42);
            this.StartBtn.TabIndex = 3;
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
            this.PhraseToGuessTextBox.TextChanged += new System.EventHandler(this.PhraseToGuessTextBox_TextChanged);
            // 
            // Value2
            // 
            this.Value2.Location = new System.Drawing.Point(40, 125);
            this.Value2.Name = "Value2";
            this.Value2.Size = new System.Drawing.Size(100, 20);
            this.Value2.TabIndex = 1;
            // 
            // Value3
            // 
            this.Value3.Location = new System.Drawing.Point(181, 125);
            this.Value3.Name = "Value3";
            this.Value3.Size = new System.Drawing.Size(100, 20);
            this.Value3.TabIndex = 2;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(187, 49);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Phrase to guess";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(69, 109);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Value2";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(212, 109);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(40, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Value3";
            // 
            // DetailTextBox
            // 
            this.DetailTextBox.Location = new System.Drawing.Point(40, 247);
            this.DetailTextBox.Name = "DetailTextBox";
            this.DetailTextBox.Size = new System.Drawing.Size(374, 148);
            this.DetailTextBox.TabIndex = 4;
            this.DetailTextBox.TabStop = false;
            this.DetailTextBox.Text = "";
            // 
            // BestGuessTextBox
            // 
            this.BestGuessTextBox.Location = new System.Drawing.Point(40, 200);
            this.BestGuessTextBox.Name = "BestGuessTextBox";
            this.BestGuessTextBox.Size = new System.Drawing.Size(374, 20);
            this.BestGuessTextBox.TabIndex = 5;
            this.BestGuessTextBox.TabStop = false;
            // 
            // CurrentGuessLabel
            // 
            this.CurrentGuessLabel.AutoSize = true;
            this.CurrentGuessLabel.Location = new System.Drawing.Point(178, 184);
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
            this.StopBtn.TabIndex = 3;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Visible = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 419);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.BestGuessTextBox);
            this.Controls.Add(this.DetailTextBox);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CurrentGuessLabel);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Value3);
            this.Controls.Add(this.Value2);
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
        private System.Windows.Forms.TextBox Value2;
        private System.Windows.Forms.TextBox Value3;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.RichTextBox DetailTextBox;
        private System.Windows.Forms.TextBox BestGuessTextBox;
        private System.Windows.Forms.Label CurrentGuessLabel;
        public System.Windows.Forms.Button StopBtn;
    }
}

