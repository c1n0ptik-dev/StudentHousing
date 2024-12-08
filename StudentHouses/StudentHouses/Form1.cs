using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace StudentHouses
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();


            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatAppearance.MouseDownBackColor = Color.Transparent;

            passwordBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginBox.Text.Trim();
            string password = passwordBox.Text.Trim();

            if (dbHelper.VerifyUser(username, password))
            {
                if (dbHelper.VerifyAdmin(username, password))
                {
                    AdminForm admin = new AdminForm();
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    StudentForm student = new StudentForm();
                    student.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Access denied!");
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                passwordBox.PasswordChar = '\0';
            }
            else
            {
                passwordBox.PasswordChar = '*';
            }
        }
    }
}