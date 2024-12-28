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
    public partial class UserControlChore : UserControl
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        int ChoreId;


        public UserControlChore(Chores chore)
        {
            InitializeComponent();

            ChoreText.Enabled = true;
            ChoreId = chore.GetChoreID();

            ChoreTitle.Text = $"{chore.GetChoreTitle()} (by {chore.GetCreatorInfo()})";
            ChoreText.Text = chore.GetChoreBody();
        }

        private void ChoreDone_Click(object sender, EventArgs e)
        {
            try
            {
                dbHelper.DeleteChore(ChoreId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while closing a chore: {ex.Message}");
            }
        }
    }
}
