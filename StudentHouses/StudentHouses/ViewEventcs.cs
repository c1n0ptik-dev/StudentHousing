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
    public partial class ViewEventcs : Form
    {
        private Events events;
        public ViewEventcs(Events eventS)
        {
            InitializeComponent();
            this.events = eventS;

            lblTitle.Text = events.GetInfo()[0];
            lblData.Text = events.GetInfo()[1];
            lblR.Text = events.GetInfo()[2];
            lblOrg.Text = events.GetInfo()[3];
            textBox.Text = events.GetInfo()[4];
        }

        private void Event_Enter(object sender, EventArgs e)
        {

        }
    }
}
