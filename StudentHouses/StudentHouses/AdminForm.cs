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


namespace StudentHouses
{
    public partial class AdminForm : Form
    {
        private Complaints submittedComplains;
        public AdminForm()
        {
            InitializeComponent();

            try
            {
                if (File.Exists("complaints.txt"))
                {
                    using (FileStream fs = new FileStream("complaints.txt", FileMode.Open, FileAccess.Read))
                    {
                        DataContractSerializer dcs = new DataContractSerializer(typeof(List<Complaints>));

                        List<Complaints> complaintsList = (List<Complaints>)dcs.ReadObject(fs);


                        foreach (var complaint in complaintsList)
                        {
                            UserControlComplaints ucbc = new UserControlComplaints(complaint);
                            complaintsPanel.Controls.Add(ucbc);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No complaints file found. Starting with an empty list.", "Information");
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
    }
}
