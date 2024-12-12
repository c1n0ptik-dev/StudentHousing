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
    public partial class UserControlDays : UserControl
    {
        private static int static_day;
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public UserControlDays()
        {
            InitializeComponent();
            static_day = Convert.ToInt32(lblDays.Text);
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void DisplayEvent(string eventDescription)
        {
            lblEvent.Text += eventDescription + "\n";
        }

        public void Days(int numday)
        {
            lblDays.Text = numday + "";
        }



        public int GetStaticDay()
        {
            return static_day;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
