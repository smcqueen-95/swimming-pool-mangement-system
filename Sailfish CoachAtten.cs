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
    public partial class Sailfish_CoachAtten : Form
    {
        public Sailfish_CoachAtten()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        COACHATTENDANCE coachAtten = new COACHATTENDANCE();

        private void Sailfish_CoachAtten_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches_atten` WHERE `Swim Team/s`='Sailfish'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coachAtten.getCoachesAtten(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches_atten` WHERE `Swim Team/s`='Sailfish'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coachAtten.getCoachesAtten(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish_Dashboard sailfishDash = new Sailfish_Dashboard();
                sailfishDash.Show();
            }
        }
    }
}
