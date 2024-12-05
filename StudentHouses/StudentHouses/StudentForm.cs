using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHouses
{
    public partial class StudentForm : Form
    {
        int month, year;
        public StudentForm()
        {
            InitializeComponent();
            Displays();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Displays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;


            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMandY.Text = monthName+" " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month) + 1;
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlPanel ucblank = new UserControlPanel();
                daysContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i < daysInMonth; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.Days(i);
                daysContainer.Controls.Add(ucdays);
            }






        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void daysContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!AcceptTC.Checked)
            {
                MessageBox.Show("You need to accept the T and C");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            daysContainer.Controls.Clear();

            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMandY.Text = monthName + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month) + 1;
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlPanel ucblank = new UserControlPanel();
                daysContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i < daysInMonth; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.Days(i);
                daysContainer.Controls.Add(ucdays);
            }


        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            daysContainer.Controls.Clear();

            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }


            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMandY.Text = monthName + " " + year;

            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month) + 1;
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlPanel ucblank = new UserControlPanel();
                daysContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i < daysInMonth; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.Days(i);
                daysContainer.Controls.Add(ucdays);
            }


        }
    }
}
