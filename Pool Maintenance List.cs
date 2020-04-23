using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Swimming_Pool_Management_System
{
    public partial class Pool_Maintenance_List : Form
    {
        public Pool_Maintenance_List()
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
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish_Dashboard sailfishDash = new Sailfish_Dashboard();
                sailfishDash.Show();
            }
            else if (labelUser.Text == "Grenfin Team Leader")
            {
                this.Hide();
                Grenfin_Dashboard grenfinDash = new Grenfin_Dashboard();
                grenfinDash.Show();
            }
            else if (labelUser.Text == "Dolphin Team Leader")
            {
                this.Hide();
                Dolphin_Dashboard dolphinDash = new Dolphin_Dashboard();
                dolphinDash.Show();
            }
            else if (labelUser.Text == "Grenada Team Leader")
            {
                this.Hide();
                Grenada_Team_Dashboard grenadaDash = new Grenada_Team_Dashboard();
                grenadaDash.Show();
            }
        }

        POOLMAINTENANCE poolMain = new POOLMAINTENANCE();

        private void Pool_Maintenance_List_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `pool_maintenance`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = poolMain.getPoolMains(command);
            dataGridView1.AllowUserToAddRows = false;

            labelUser.Text = GLOBAL.userType;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `pool_maintenance`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = poolMain.getPoolMains(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Hide();
                Pool_Maintenance poolMain = new Pool_Maintenance();
                poolMain.Show();
            }
        }
    }
}
