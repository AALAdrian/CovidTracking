using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CovidTracking
{
    public partial class CovidTracking : Form
    {
        public CovidTracking()
        {
            InitializeComponent();
            FolderBrowserDialog folderDlg = new();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                directory.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void HasText()
        {
            if (!string.IsNullOrEmpty(LastName.Text) && 
                !string.IsNullOrEmpty(FirstName.Text) &&
                !string.IsNullOrEmpty(ContactNo.Text) &&
                !string.IsNullOrEmpty(EmailAdd.Text) &&
                !string.IsNullOrEmpty(DoB.Text) &&
                !string.IsNullOrEmpty(Temperature.Text)
                )
            {
                MessageBox.Show("DATA IS COMPLETE");
                //GetInfo();
            }
            else
            {
                MessageBox.Show("Data is NOT COMPLETE");
            }
        }
        private void GetInfo()
        {

            //bool[] trackingQuest = new bool[3];
            //trackingQuest[1] = Q1chkbx.Checked;
            //trackingQuest[2] = Q2chkbx.Checked;
            //trackingQuest[3] = Q3chkbx.Checked;
            string trackingInfo = $"{LastName.Text},{FirstName.Text},{ContactNo.Text},{EmailAdd.Text},{DoB.Text},{Temperature.Text},";
        }
        private void WritetoFile(string info, bool[] questions)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(directory.Text, "WriteLines.txt"), true))
            {
                outputFile.WriteLine("Fourth Line");
            }
        }
        private void Track(object sender, EventArgs e)
        {

            //if (Directory.Exists(@"C:\Temp\Demo"))
            //{
            //    MessageBox.Show("The Directory Exists!");
            // }
            //else
            //{
            //    MessageBox.Show("The Does Not Directory Exists!");
            //}
            HasText();
        }
    }
}
