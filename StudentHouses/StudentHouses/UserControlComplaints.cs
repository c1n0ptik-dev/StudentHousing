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
    public partial class UserControlComplaints : UserControl
    {
        public UserControlComplaints(Complaints complain)
        {
            InitializeComponent();
            string studentName = null;

            nameLabel.Text = complain.GetNameNumber();
            textBox1.Text = complain.GetComplain();
        }

        private void UserControlComplaints_Load(object sender, EventArgs e)
        {
            
        }
    }
}
