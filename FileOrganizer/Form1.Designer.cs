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
            this.startOrganizeButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.topLevelComboBox = new System.Windows.Forms.ComboBox();
            this.topLevelLabel = new System.Windows.Forms.Label();
            this.FrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderSelectTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.showTreeButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.generatePreviewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.browseRestore = new System.Windows.Forms.Button();
            this.restoreTextBox = new System.Windows.Forms.TextBox();
            this.restoreButton = new System.Windows.Forms.Button();
            this.currentTree = new System.Windows.Forms.TreeView();
            this.previewTree = new System.Windows.Forms.TreeView();
            this.currentTreeLabel = new System.Windows.Forms.Label();
            this.previewTreeLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startOrganizeButton
            // 
            this.startOrganizeButton.Enabled = false;
            this.startOrganizeButton.Location = new System.Drawing.Point(713, 481);
            this.startOrganizeButton.Name = "startOrganizeButton";
            this.startOrganizeButton.Size = new System.Drawing.Size(75, 23);
            this.startOrganizeButton.TabIndex = 0;
            this.startOrganizeButton.Text = "Organize";
            this.startOrganizeButton.UseVisualStyleBackColor = true;
            this.startOrganizeButton.Click += new System.EventHandler(this.organizeButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // topLevelComboBox
            // 
            this.topLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.FrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FrequencyComboBox.FormattingEnabled = true;
            this.FrequencyComboBox.Items.AddRange(new object[] {
            "Monthly",
            "Yearly"});
            this.FrequencyComboBox.Location = new System.Drawing.Point(94, 92);
            this.FrequencyComboBox.Name = "FrequencyComboBox";
            this.FrequencyComboBox.Size = new System.Drawing.Size(121, 23);
            this.FrequencyComboBox.TabIndex = 4;
            this.FrequencyComboBox.SelectedIndexChanged += new System.EventHandler(this.FrequencyComboBox_SelectedIndexChanged);
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
            // folderSelectTextBox
            // 
            this.folderSelectTextBox.Location = new System.Drawing.Point(94, 11);
            this.folderSelectTextBox.Name = "folderSelectTextBox";
            this.folderSelectTextBox.Size = new System.Drawing.Size(244, 23);
            this.folderSelectTextBox.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 481);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(695, 23);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // showTreeButton
            // 
            this.showTreeButton.Location = new System.Drawing.Point(344, 12);
            this.showTreeButton.Name = "showTreeButton";
            this.showTreeButton.Size = new System.Drawing.Size(75, 23);
            this.showTreeButton.TabIndex = 10;
            this.showTreeButton.Text = "Show Tree";
            this.showTreeButton.UseVisualStyleBackColor = true;
            this.showTreeButton.Click += new System.EventHandler(this.showTreeButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 121);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Organize by Author?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // generatePreviewButton
            // 
            this.generatePreviewButton.Enabled = false;
            this.generatePreviewButton.Location = new System.Drawing.Point(221, 54);
            this.generatePreviewButton.Name = "generatePreviewButton";
            this.generatePreviewButton.Size = new System.Drawing.Size(198, 86);
            this.generatePreviewButton.TabIndex = 12;
            this.generatePreviewButton.Text = "Generate Preview";
            this.generatePreviewButton.UseVisualStyleBackColor = true;
            this.generatePreviewButton.Click += new System.EventHandler(this.generatePreviewButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Restore from File:";
            // 
            // browseRestore
            // 
            this.browseRestore.Location = new System.Drawing.Point(434, 54);
            this.browseRestore.Name = "browseRestore";
            this.browseRestore.Size = new System.Drawing.Size(75, 23);
            this.browseRestore.TabIndex = 14;
            this.browseRestore.Text = "Browse...";
            this.browseRestore.UseVisualStyleBackColor = true;
            // 
            // restoreTextBox
            // 
            this.restoreTextBox.Location = new System.Drawing.Point(515, 54);
            this.restoreTextBox.Name = "restoreTextBox";
            this.restoreTextBox.Size = new System.Drawing.Size(273, 23);
            this.restoreTextBox.TabIndex = 15;
            // 
            // restoreButton
            // 
            this.restoreButton.Location = new System.Drawing.Point(434, 83);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(75, 23);
            this.restoreButton.TabIndex = 16;
            this.restoreButton.Text = "Restore";
            this.restoreButton.UseVisualStyleBackColor = true;
            // 
            // currentTree
            // 
            this.currentTree.Location = new System.Drawing.Point(12, 176);
            this.currentTree.Name = "currentTree";
            this.currentTree.Size = new System.Drawing.Size(326, 299);
            this.currentTree.TabIndex = 17;
            // 
            // previewTree
            // 
            this.previewTree.Location = new System.Drawing.Point(344, 176);
            this.previewTree.Name = "previewTree";
            this.previewTree.Size = new System.Drawing.Size(326, 299);
            this.previewTree.TabIndex = 18;
            this.previewTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.previewTree_AfterSelect);
            // 
            // currentTreeLabel
            // 
            this.currentTreeLabel.AutoSize = true;
            this.currentTreeLabel.Location = new System.Drawing.Point(12, 158);
            this.currentTreeLabel.Name = "currentTreeLabel";
            this.currentTreeLabel.Size = new System.Drawing.Size(74, 15);
            this.currentTreeLabel.TabIndex = 19;
            this.currentTreeLabel.Text = "Current Tree:";
            // 
            // previewTreeLable
            // 
            this.previewTreeLable.AutoSize = true;
            this.previewTreeLable.Location = new System.Drawing.Point(344, 158);
            this.previewTreeLable.Name = "previewTreeLable";
            this.previewTreeLable.Size = new System.Drawing.Size(75, 15);
            this.previewTreeLable.TabIndex = 20;
            this.previewTreeLable.Text = "Preview Tree:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.previewTreeLable);
            this.Controls.Add(this.currentTreeLabel);
            this.Controls.Add(this.previewTree);
            this.Controls.Add(this.currentTree);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(this.restoreTextBox);
            this.Controls.Add(this.browseRestore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generatePreviewButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.showTreeButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.folderSelectTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.frequencyLabel);
            this.Controls.Add(this.FrequencyComboBox);
            this.Controls.Add(this.topLevelLabel);
            this.Controls.Add(this.topLevelComboBox);
            this.Controls.Add(this.startOrganizeButton);
            this.Name = "Form1";
            this.Text = "File Organizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startOrganizeButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox topLevelComboBox;
        private System.Windows.Forms.Label topLevelLabel;
        private System.Windows.Forms.ComboBox FrequencyComboBox;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox folderSelectTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button showTreeButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button generatePreviewButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseRestore;
        private System.Windows.Forms.TextBox restoreTextBox;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.TreeView currentTree;
        private System.Windows.Forms.TreeView previewTree;
        private System.Windows.Forms.Label currentTreeLabel;
        private System.Windows.Forms.Label previewTreeLable;
    }
}
