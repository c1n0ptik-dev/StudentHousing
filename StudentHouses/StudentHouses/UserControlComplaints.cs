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
        DatabaseHelper dbHelper = new DatabaseHelper();
        int complaintid;
        private int complaintCreatorID;

        public UserControlComplaints(Complaints complain)
        {
            InitializeComponent();
            //string studentName = null;
            complaintid = complain.GetComplaintID();
            complaintCreatorID = complain.CreatorID;

            nameLabel.Text = $"{complain.CreatorName} (ID: {complain.CreatorID})";
            textBox1.Text = complain.GetComplain();

            //nameLabel.Text = $"Name: {complain.CreatorName}";
            //idLabel.Text = $"ID: {complain.CreatorID}";

            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void UserControlComplaints_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbHelper.DeleteComplaint(complaintid);
        }

        private void BanBTN_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{complaintCreatorID}");

            dbHelper.BanUser(complaintCreatorID);
        }
    }
}
