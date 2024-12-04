using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentHouses
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent(); 
            


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
            DateTime startOfTheMonth = new DateTime(now.Year, now.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            int dayOfTheWeek = (int)startOfTheMonth.DayOfWeek;  // 0 = Sunday, 1 = Monday, ..., 6 = Saturday

            // Add blank UserControl for the days before the start of the month
            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daysContainer.Controls.Add(ucblank);
            }

            // Add UserControl for each day of the month
            for (int day = 1; day <= daysInMonth; day++)
            {
                UserControlBlank ucDay = new UserControlBlank();  // Assuming UserControlDay is the control that displays the day number
                ucDay.SetDay(day);  // Set the actual day number on the control
                daysContainer.Controls.Add(ucDay);
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
            UserControlBlank ucblank = new UserControlBlank();
            daysContainer.Controls.Add(ucblank);
        }
    }
}
