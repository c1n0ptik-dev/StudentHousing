using ServiceStack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace StudentHouses
{
    public partial class StudentForm : Form
    {
        static int static_month, static_year;
        int StudentID;
        int month, year;
        Studentcs student1;
        List<Chores> chores = new List<Chores>();
        DatabaseHelper dbHelper = new DatabaseHelper();
        Form ParentForm;

        public StudentForm(int id, Form Form1)
        {
            InitializeComponent();
            StudentID = id;
            ParentForm = Form1;

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

            List<string> AvailableStudents = dbHelper.GetAllUserNames();

            foreach (string s in AvailableStudents)
            {
                StudentsComboBox.Items.Add(s);
            }

            chores = dbHelper.GetChoresByUserID(StudentID).ToList();

            UpdateChores();

            Displays();
        }

        private void UpdateChores()
        {
            try
            {
                ChoresContainer.Controls.Clear();

                foreach (Chores chore in chores)
                {
                    if(chore.ResponsibleID == StudentID)
                    {
                        UserControlChore userChores = new UserControlChore(chore, chores);
                        ChoresContainer.Controls.Add(userChores);
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while updating chores: {ex.Message}");
            }
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
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d"));

            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlPanel ucblank = new UserControlPanel();
                daysContainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.Days(i);

                DateTime currentDate = new DateTime(year, month, i);

                List<Events> eventsForDay = dbHelper.GetEventsForDate(currentDate);

                ucdays.DisplayEvents(eventsForDay);

                daysContainer.Controls.Add(ucdays);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!student1.Banned())
            {

                string creatorName = student1.GetStudent();
                int creatorId = student1.GetStudentId();
                string complain = txtComplain.Text;
                dbHelper.AddComplaint(creatorName, creatorId, complain);
                txtComplain.Text = "";
            }
            else
            {
                MessageBox.Show("You are banned from the complaints!", "Banned!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            int creatorID = student1.GetStudentId();
            string choreType = ChoreType.Text;
            string choreText = ChoreText.Text;
            int responsibleID = dbHelper.GetStudentIdByName(StudentsComboBox.Text);
            string creatorName = student1.GetStudent();

            ChoreType.SelectedIndex = -1;
            StudentsComboBox.SelectedIndex = -1;
            ChoreText.Text = string.Empty;


           
            
                int choreID = dbHelper.GetLastInsertedChoreId() + 1;

                Chores newChore = new Chores(
                    choreID,
                    student1.GetStudentId(),
                    student1,          
                    choreType,             
                    choreText,             
                    choreText,           
                    choreType,         
                    responsibleID        
                );

                chores.Add(newChore);

                dbHelper.AddChore(creatorID, creatorName, choreType, choreText, responsibleID);


                UpdateChores();

                MessageBox.Show("Chore added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateChores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateChores();
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Normal;
            ParentForm.BringToFront();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            daysContainer.Controls.Clear();
            Displays();
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

