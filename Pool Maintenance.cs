using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swimming_Pool_Management_System
{
    public partial class Pool_Maintenance : Form
    {
        public Pool_Maintenance()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Hide();
                Pool_Maintenance_List poolMainList = new Pool_Maintenance_List();
                poolMainList.Show();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //create a function to verify data
        bool verif()
        {
            if ((textBox1.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }

        POOLMAINTENANCE poolMain = new POOLMAINTENANCE();

        private void addBtn_Click(object sender, EventArgs e)
        {
            DateTime dateOfUnav = dateTimePicker1.Value;
            DateTime dateOfAvail = dateTimePicker1.Value;
            string typeOfMain = textBox1.Text;

            if (verif())
            {
                if (poolMain.insertPoolMain(dateOfUnav, dateOfAvail, typeOfMain))
                {
                    MessageBox.Show("Pool Maintenance Added", "Add Pool Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Pool Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Pool_Maintenance_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
    }
}
