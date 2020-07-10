using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOrganizer
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        

        private void organizeButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Are you sure you want to reorganize {folderSelectTextBox.Text}?", "Confirm Action", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Organizer.Folder = folderSelectTextBox.Text;
                Organizer.OrganizeByAuthor = checkBox1.Checked;
                Organizer.Frequency = FrequencyComboBox.SelectedItem.ToString();
                Organizer.AddFolder(folderSelectTextBox.Text);
                Organizer.Organize(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePreviewOrganize();
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
                startOrganizeButton.Enabled = true;
            }
        }

        private void FrequencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePreviewOrganize();
        }

        private void generatePreviewButton_Click(object sender, EventArgs e)
        {
            
            
        }

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
            List<TreeNode> treeNodes = new List<TreeNode>(GenerateNodesRecursively(folderSelectTextBox.Text));
            currentTree.Nodes.Clear();
            foreach (TreeNode node in treeNodes)
            {
                currentTree.Nodes.Add(node);
            }

            //currentTree.ExpandAll();
            currentTree.Nodes[0].EnsureVisible();


        }

        private void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
