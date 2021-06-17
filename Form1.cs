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
            SavingPath();
        }
        private void SavingPath()
        {
            FolderBrowserDialog folderDlg = new();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                directory.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
        private void Reset(object sender, EventArgs e)
        {
            LastName.Clear();
            FirstName.Clear();
            ContactNo.Clear();
            EmailAdd.Clear();
            Temperature.Clear();
            Q1chkbx.Checked = false;
            Q2chkbx.Checked = false;
            Q3chkbx.Checked = false;
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
                MessageBox.Show("DATA IS SAVE");
                GetInfo();
            }
            else
            {
                MessageBox.Show("Data is NOT COMPLETE", "ERROR");
            }
        }
        private void GetInfo()
        {
            string trackingQuest = "";
            if (!Q1chkbx.Checked)
            {
                trackingQuest += ", no";
            }
            else
            {
                trackingQuest += ", yes";
            }
            if (!Q2chkbx.Checked)
            {
                trackingQuest += ", no";
            }
            else
            {
                trackingQuest += ", yes";
            }
            if (!Q3chkbx.Checked)
            {
                trackingQuest += ", no";
            }
            else
            {
                trackingQuest += ", yes";
            }
            string trackingInfo = $"{LastName.Text},{FirstName.Text},{ContactNo.Text},{EmailAdd.Text},{DoB.Text},{Temperature.Text}C";
            WritetoFile(trackingInfo+trackingQuest);
        }
        private void WritetoFile(string info)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(directory.Text, $"{DateTime.Now.ToString("yyyy-MM-dd_hh")}.txt"), true))
            {
                outputFile.WriteLine(info);
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
