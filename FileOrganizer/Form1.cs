using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOrganizer
{
    public partial class Form1 : Form
    {
        public delegate void UpdateProgressBar();
        public UpdateProgressBar updateProgress;
        public Form1()
        {
            InitializeComponent();
            updateProgress = new UpdateProgressBar(UpdateProgress);
        }

        private void UpdateProgress()
        {
            progressBar1.Value = Organizer.getProgress();
        }

        private void organizeButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Are you sure you want to reorganize {folderSelectTextBox.Text}?", "Confirm Action", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // TODO: this will be true in end
                StartOrganize(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Organizer.Form = this;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePreviewOrganize();
            // TODO: Grey out and check author box when author is top-level
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Browse for target folder button click
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                DialogResult result = folderBrowser.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderSelectTextBox.Text = folderBrowser.SelectedPath;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Insufficient privileges to access selected folder.", "Error", MessageBoxButtons.OK);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Enable/disable Generate Preview and Organize button based on drop down selectiosn
        private void updatePreviewOrganize()
        {
            if(topLevelComboBox.SelectedItem != null && FrequencyComboBox.SelectedItem != null)
            {
                generatePreviewButton.Enabled = true;
                startOrganizeButton.Enabled = true;
            }
            else
            {
                generatePreviewButton.Enabled = false;
                startOrganizeButton.Enabled = false;
            }
        }

        private void FrequencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePreviewOrganize();
        }

        // Does what organize button does, but then show preview tree
        private void generatePreviewButton_Click(object sender, EventArgs e)
        {
            previewTree.Visible = false;
            previewTree.Nodes.Clear();
            previewTree.Visible = true;
            StartOrganize(false);
            Organizer.GeneratePreview();
            while (Organizer.getPreviewTreeProgress() != 100)
            {
                progressBar1.Value = Organizer.getPreviewTreeProgress();
                Thread.Sleep(200);
            }
            progressBar1.Value = Organizer.getPreviewTreeProgress();
            TreeNode nodes = (TreeNode)Organizer.PreviewTree.Clone();
            foreach (TreeNode node in nodes.Nodes)
            {
                previewTree.Nodes.Add(node);
            }
        }

        private void StartOrganize(bool performMove)
        {
            Organizer.Reinitialize();
            Organizer.Folder = folderSelectTextBox.Text;
            Organizer.OrganizeByAuthor = checkBox1.Checked;
            Organizer.Frequency = FrequencyComboBox.SelectedItem.ToString();
            Organizer.AddFolder(folderSelectTextBox.Text);
            Organizer.Organize(performMove);
        }

        // TODO: Refactor this into Organizer class
        private void GenerateTree(string path)
        {
            List<TreeNode> treeNodes = new List<TreeNode>(GenerateNodesRecursively(path));
            currentTree.Nodes.Clear();
            foreach (TreeNode node in treeNodes)
            {
                currentTree.Nodes.Add(node);
            }
        }
        
        // TODO: Refactor this into Organizer class
        private List<TreeNode>  GenerateNodesRecursively(string path)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            string[] subdirectories = Directory.GetDirectories(path);
            if(!(subdirectories == null || subdirectories.Length == 0))
            {
                foreach(string subdirectory in subdirectories)
                {

                    TreeNode tree = new TreeNode(Path.GetFileName(subdirectory), GenerateNodesRecursively(subdirectory).ToArray());
                    treeNodes.Add(tree);
                }
            }
            return treeNodes;
        }


        private void showTreeButton_Click(object sender, EventArgs e)
        {
            currentTree.Nodes.Add(new TreeNode("Generating Nodes..."));
            GenerateTree(folderSelectTextBox.Text);

            // The following takes too long
            //currentTree.ExpandAll();

            currentTree.Nodes[0].EnsureVisible();


        }

        private void previewTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

    
    }
}