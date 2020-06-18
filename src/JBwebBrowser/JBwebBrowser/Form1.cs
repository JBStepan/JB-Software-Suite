/*
 * This is the JB Stepan Web Browser part of the JB Software Suite
 * Github: https://github.com/tonymoooon543/JB-Software-Suite
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBwebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Closes the window when exit if clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Tells the end user the info of where this came from
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This web browser is a part of the JB Software Suite. Made by JB Stepan");
        }

        // Makes the 'Navigate' button work
        private void btnNav_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }
        
        // Makes naviagting to the page in one function
        private void NavigateToPage()
        {
            webBrowser.Navigate(txtNavBar.Text);
        }

        // If enter is pressed while the webbrowser is focused, navigate the page
        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == (char)(ConsoleKey.Enter))
            {
                NavigateToPage();
            }
        }

        // Saving our asses
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Alpha version of the JBSS Web Browser, this does not reflect the final look of the app ;)", "Saving Our Asses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
