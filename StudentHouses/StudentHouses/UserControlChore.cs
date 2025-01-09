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
        List<Chores> Chores;

        public UserControlChore(Chores chore, List<Chores> chores)
        {
            InitializeComponent();
            Chores = chores; 

            ChoreText.Enabled = true;
            ChoreId = chore.GetChoreID();

            ChoreTitle.Text = $"{chore.GetChoreTitle()} (by {chore.GetCreatorInfo()})";
            ChoreText.Text = chore.GetChoreBody();
        }

        private void ChoreDone_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(ChoreId));

            try
            {
                dbHelper.DeleteChore(ChoreId);
                Chores.RemoveAll(c => c.ChoreID == ChoreId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while closing a chore: {ex.Message}");
            }
        }
    }
}
