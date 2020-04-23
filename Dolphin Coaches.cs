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
    public partial class Dolphin_Coaches : Form
    {
        public Dolphin_Coaches()
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
            else if (labelUser.Text == "Dolphin Team Leader")
            {
                this.Hide();
                Dolphin_Dashboard dolphinDash = new Dolphin_Dashboard();
                dolphinDash.Show();
            }
        }

        COACHES coach = new COACHES();

        private void Dolphin_Coaches_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches` WHERE `Swim Team/s`='Dolphin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches` WHERE `Swim Team/s`='Dolphin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Remove_Coach editRemoveCoach = new Edit_Remove_Coach();
            editRemoveCoach.Show();
        }
    }
}
