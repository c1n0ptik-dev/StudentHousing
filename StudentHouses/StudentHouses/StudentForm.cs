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
using ServiceStack;
using ServiceStack.Script;
using System.Web;

namespace StudentHouses
{
    public partial class StudentForm : Form
    {
        static int static_month, static_year;
        int StudentID;
        int month, year;
        Studentcs student1;
        List<Complaints> complaintList = new List<Complaints>();
        List<Chores> chores = new List<Chores>();   
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

            //Fetch avaliable studnets
            List<string> AvailableStudents = dbHelper.GetAllUserNames();
            
            
            foreach (string s in AvailableStudents)
            {
                StudentsComboBox.Items.Add(s);
            }

            //UserControlChore userControlChore = new UserControlChore();
            //flowLayoutPanel1.Controls.Add(userControlChore);

            UpdateChores();

            Displays();
        }

        private void UpdateChores()
        {
            try
            {
                Chores[] chores = dbHelper.GetChoresByUserID(student1.GetStudentId());
                ChoresContainer.Controls.Clear();

                foreach (Chores chore in chores)
                {
                    UserControlChore userChores = new UserControlChore(chore);
                    ChoresContainer.Controls.Add(userChores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while fetching student chores: {ex.Message}");
            }

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

            static_month = month;
            static_year = year;

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

                DateTime currentDate = new DateTime(year, month, i);


                List<string> eventsForDay = dbHelper.GetEventsForDate(currentDate);

              
                foreach (var eventDescription in eventsForDay)
                {
                    ucdays.DisplayEvent(eventDescription);
                }

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

            static_month = month;
            static_year = year;

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                string title = titleBox.Text;
                string time = dateTimePicker.Value.ToString("yyyy-MM-dd");
                int roomUsed = Convert.ToInt32(roomUsed1.Text);
                string org = orgBox.Text;
                string description = descBox.Text;

                dbHelper.AddEvent(title, time, roomUsed, org, description);

                titleBox.Text = string.Empty;
                dateTimePicker.Value = DateTime.Now;
                roomUsed1.Text = string.Empty;
                orgBox.Text = string.Empty;
                descBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("You need to accept T and C.");
            }
        }

        private void StudentForm_Load_1(object sender, EventArgs e)
        {
        
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

            static_month = month;
            static_year = year;

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

        private void button4_Click(object sender, EventArgs e)
        {
            daysContainer.Controls.Clear();
            Displays();

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int creatorID = student1.GetStudentId();
            string choreType = ChoreType.Text;
            string choreText = ChoreText.Text;
            int responsibleID = dbHelper.GetStudentIdByName(StudentsComboBox.Text);
            string creatorName = student1.GetStudent();


            if (TCstudchores.Checked)
            {
                dbHelper.AddChore(creatorID, creatorName, choreType, choreText, responsibleID);
                MessageBox.Show("Chore added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //MessageBox.Show($"{creatorID},{choreType}, {choreText}, {responsibleID}");
            }
            else
            {
                MessageBox.Show("Please accept our terms and services to add a Chore.", "Accetp our T&C!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateChores();
        }

        public int GetStaticMonth()
        {
            return static_month;
        }

        public int GetStaticYear()
        {
            return static_year;
        }
    }
}
