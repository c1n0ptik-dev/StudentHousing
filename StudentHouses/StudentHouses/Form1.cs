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
        public Form1()
        {
            InitializeComponent();

          
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatAppearance.MouseDownBackColor = Color.Transparent;


            passwordBox.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string loginAdmin = loginBox.Text;
            string passwordAdmin = passwordBox.Text;

            if (loginAdmin == "Admin" && passwordAdmin == "pas123")
            {
                AdminForm admin = new AdminForm();
                admin.Show();
                this.Hide();
            }
            else if (loginAdmin == "Student" && passwordAdmin == "pas123")
            {
                StudentForm student = new StudentForm();
                student.Show();
                this.Hide();
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