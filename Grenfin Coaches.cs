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
    public partial class Grenfin_Coaches : Form
    {
        public Grenfin_Coaches()
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
                Grenfin_Dashboard grenfinDash = new Grenfin_Dashboard();
                grenfinDash.Show();
            }
        }

        COACHES coach = new COACHES();

        private void Grenfin_Coaches_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches` WHERE `Swim Team/s`='Grenfin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches` WHERE `Swim Team/s`='Grenfin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Remove_Coach editRemove = new Edit_Remove_Coach();
            editRemove.Show();
        }
    }
}
