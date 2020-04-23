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
    public partial class Grenada_Team_CoachAtten : Form
    {
        public Grenada_Team_CoachAtten()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Grenada Team Leader")
            {
                this.Hide();
                Grenada_Team_Dashboard grenTeamdash = new Grenada_Team_Dashboard();
                grenTeamdash.Show();
            }
        }

        COACHATTENDANCE coachAtten = new COACHATTENDANCE();

        private void Grenada_Team_CoachAtten_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches_atten` WHERE `Swim Team/s`='Grenada'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coachAtten.getCoachesAtten(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches_atten` WHERE `Swim Team/s`='Grenada'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coachAtten.getCoachesAtten(command);
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
