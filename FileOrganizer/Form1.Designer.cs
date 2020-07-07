namespace FileOrganizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startOrganize = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topLevelComboBox = new System.Windows.Forms.ComboBox();
            this.topLevelLabel = new System.Windows.Forms.Label();
            this.FrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startOrganize
            // 
            this.startOrganize.Location = new System.Drawing.Point(713, 481);
            this.startOrganize.Name = "startOrganize";
            this.startOrganize.Size = new System.Drawing.Size(75, 23);
            this.startOrganize.TabIndex = 0;
            this.startOrganize.Text = "Organize";
            this.startOrganize.UseVisualStyleBackColor = true;
            this.startOrganize.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // topLevelComboBox
            // 
            this.topLevelComboBox.FormattingEnabled = true;
            this.topLevelComboBox.Items.AddRange(new object[] {
            "Date Created",
            "Author"});
            this.topLevelComboBox.Location = new System.Drawing.Point(94, 55);
            this.topLevelComboBox.Name = "topLevelComboBox";
            this.topLevelComboBox.Size = new System.Drawing.Size(121, 23);
            this.topLevelComboBox.TabIndex = 2;
            this.topLevelComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // topLevelLabel
            // 
            this.topLevelLabel.AutoSize = true;
            this.topLevelLabel.Location = new System.Drawing.Point(12, 58);
            this.topLevelLabel.Name = "topLevelLabel";
            this.topLevelLabel.Size = new System.Drawing.Size(58, 15);
            this.topLevelLabel.TabIndex = 3;
            this.topLevelLabel.Text = "Top-Level";
            this.topLevelLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrequencyComboBox
            // 
            this.FrequencyComboBox.FormattingEnabled = true;
            this.FrequencyComboBox.Items.AddRange(new object[] {
            "Monthly",
            "Yearly"});
            this.FrequencyComboBox.Location = new System.Drawing.Point(94, 92);
            this.FrequencyComboBox.Name = "FrequencyComboBox";
            this.FrequencyComboBox.Size = new System.Drawing.Size(121, 23);
            this.FrequencyComboBox.TabIndex = 4;
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(12, 92);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(62, 15);
            this.frequencyLabel.TabIndex = 5;
            this.frequencyLabel.Text = "Frequency";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(12, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 7;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 23);
            this.textBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.FrequencyComboBox);
            this.Controls.Add(this.topLevelLabel);
            this.Controls.Add(this.topLevelComboBox);
            this.Controls.Add(this.startOrganize);
            this.Name = "Form1";
            this.Text = "File Organizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startOrganize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox topLevelComboBox;
        private System.Windows.Forms.Label topLevelLabel;
        private System.Windows.Forms.ComboBox FrequencyComboBox;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

