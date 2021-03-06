/*
 * This is the JB Stepan Word Prosessor part of the JB Software Suite
 * Github: https://github.com/tonymoooon543/JB-Software-Suite
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace JBWordProsessor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region FileHandling
        // Makes the function for opening files
        private void Openfile()
        {
            // From Microsoft, so all rights go to them
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
                rtb1.AppendText(fileContent);
            }

            
        }

        // Makes the function for saving files
        private void SaveFile()
        {
            // From Microsoft, so all rights go to them
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, rtb1.Text);
            }
        }
        #endregion

        private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();

        /// sets saving for menustrip save
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// sets button for opening
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openfile();
        }

        /// sets exit button in the menu strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// When the window loads display message
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Alpha version of the JBSS Word Prosessor, this does not reflect the final look of the app ;)", "Saving Our Asses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// clears whar ever is in the richtextbox
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb1.Clear();
        }

        /// New window
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Creates new intence of the method
            Form1 form2 = new Form1();
            // the shows it
            form2.Show();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enWordWrap.Checked == true)
            {
                rtb1.WordWrap = true;
            }
            // else if its not, then disable wordwrap
            else if (enWordWrap.Checked == false)
            {
                rtb1.WordWrap = false;
            }
        }

        /// When Clicked will append the current date and time
        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            string date = localDate.ToString();
            rtb1.AppendText(date);
        }

        // Help
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;
            printDialog.Document = docToPrint;
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = rtb1.Font;
            fontDialog1.Color = rtb1.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                rtb1.Font = fontDialog1.Font;
                rtb1.ForeColor = fontDialog1.Color;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}