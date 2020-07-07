using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOrganizer
{
    public partial class Form1 : Form
    {

        private string _targetFolder;
        public string TargetFolder
        {
            get { return _targetFolder; }
            set { _targetFolder = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Are you sure you want to reorganize {_targetFolder}?", "Confirm Action", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // Do action
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
