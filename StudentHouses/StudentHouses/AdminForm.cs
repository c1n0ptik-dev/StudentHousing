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
        

        private DatabaseHelper dbHelper;

        public AdminForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            BannedUsersTable.CellClick += BannedUsersTable_CellClick;
            LoadBannedUsers();

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

        private void LoadBannedUsers()
        {
            var dataTable = dbHelper.GetBannedUsers();
            BannedUsersTable.DataSource = dataTable;

            if (!BannedUsersTable.Columns.Contains("Unban"))
            {
                var unbanButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Text = "Unban",
                    UseColumnTextForButtonValue = true,
                    Name = "Unban"
                };
                BannedUsersTable.Columns.Add(unbanButtonColumn);
            }
        }

        private void BannedUsersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BannedUsersTable.Columns["Unban"].Index && e.RowIndex >= 0)
            {
                var username = BannedUsersTable.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                dbHelper.UnbanUser(username);
                LoadBannedUsers(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadBannedUsers();
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
              
                string username = UsernameBox.Text.Trim();
                string password = PasswordBox.Text.Trim();
                string fullName = FullNameBox.Text.Trim();
                string email = EmailBox.Text.Trim();
                bool isAdmin = checkBox.Checked;

                Console.WriteLine($"Full Name Before Insert: {fullName}"); 

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

                UsernameBox.Clear();
                PasswordBox.Clear();
                FullNameBox.Clear();
                RoomNumBox.Clear();
                EmailBox.Clear();
                checkBox.Checked = false;
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
