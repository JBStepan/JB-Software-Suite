using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int monthDay = DateTime.Now.Day;
            var dayOfWeek = DateTime.Now.DayOfWeek;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh.ToString();
            }
            else
            {
                time += hh.ToString();
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm.ToString();
            }
            else
            {
                time += mm.ToString();
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss.ToString();
            }
            else
            {
                time += ss.ToString();
            }

            //update label
            label1.Text = time;

            label2.Text = year.ToString();

            label3.Text = dayOfWeek.ToString();

            label4.Text = month.ToString();

            label5.Text = monthDay.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // timer interval
            timer1.Interval = 1000;

            timer1.Tick += new EventHandler(this.timer1_Tick);

            // start timer when the app loads
            timer1.Start();
        }
    }
}
