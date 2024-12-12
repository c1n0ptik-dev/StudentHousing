using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Serialization;
using System.Xml;
using NpgsqlTypes;

namespace StudentHouses
{
    public partial class StudentForm : Form
    {
        int StudentID;
        int month, year;
        Studentcs student1;
        List<Complaints> complaintList = new List<Complaints>();
        DatabaseHelper dbHelper = new DatabaseHelper();


        public StudentForm(int id)
        {
            InitializeComponent();
            StudentID = id;

            var studentData = dbHelper.GetStudentData(StudentID);
            if (studentData.HasValue) 
            {
                var data = studentData.Value; 
                student1 = new Studentcs(
                    data.Name,
                    data.RoomNumber,
                    data.StudentId,
                    data.StudentEmail,
                    data.BannedForComplaints
                );
            }
            else
            {
                MessageBox.Show("Student data not found.");
                this.Close();
            }

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
            if (!student1.Banned())
            {
                if (AcceptTC.Checked)
                {
                    bool isAnonymous = anonymousCheckBox.Checked;
                    string creatorName = student1.GetStudent();
                    int creatorId = student1.GetStudentId();
                    string complain = txtComplain.Text;

                    dbHelper.AddComplaint(creatorName, creatorId, complain, isAnonymous);

                    anonymousCheckBox.Checked = false;
                    txtComplain.Text = "";
                }
                else
                {
                    MessageBox.Show("You need to accept out Terms And Services Policy!");
                }
            }
            else
            {
                MessageBox.Show("You are banned form the complaints!", "Banned!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
