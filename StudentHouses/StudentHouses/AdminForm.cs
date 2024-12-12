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
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StudentHouses
{
    public partial class AdminForm : Form
    {
        private Complaints submittedComplains;

        private DatabaseHelper dbHelper;

        public AdminForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            updateComplaints();
        }

        public void updateComplaints()
        {
            try
            {
                complaintsPanel.Controls.Clear();

                List<Complaints> complaintsList = dbHelper.GetAllComplaints();

              
                foreach (var complaint in complaintsList)
                {
                    UserControlComplaints ucbc = new UserControlComplaints(complaint);
                    complaintsPanel.Controls.Add(ucbc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading complaints: {ex.Message}", "Error");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void complaintsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect and validate user input
                string username = UsernameBox.Text.Trim();
                string password = PasswordBox.Text.Trim();
                string fullName = FullNameBox.Text.Trim();
                string email = EmailBox.Text.Trim();
                bool isAdmin = IsAdminBox.Text.Trim().Equals("True", StringComparison.OrdinalIgnoreCase);

                Console.WriteLine($"Full Name Before Insert: {fullName}"); // Debugging Log

                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(fullName) ||
                    string.IsNullOrWhiteSpace(email) ||
                    !int.TryParse(RoomNumBox.Text.Trim(), out int roomNumber))
                {
                    MessageBox.Show("All fields are required, and Room Number must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dbHelper.IncertRecord(username, password, fullName, roomNumber, email, isAdmin);

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the input fields after successful registration
                UsernameBox.Clear();
                PasswordBox.Clear();
                FullNameBox.Clear();
                RoomNumBox.Clear();
                EmailBox.Clear();
                IsAdminBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateComplaints();
        }
    }
}
