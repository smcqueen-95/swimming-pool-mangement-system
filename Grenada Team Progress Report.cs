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
    public partial class Grenada_Team_Progress_Report : Form
    {
        public Grenada_Team_Progress_Report()
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
                Grenada_Swim_Team grenSwim = new Grenada_Swim_Team();
                grenSwim.Show();
            }
            else if (labelUser.Text == "Grenada Team Leader")
            {
                this.Hide();
                Grenada_Swim_Team grenSwim = new Grenada_Swim_Team();
                grenSwim.Show();
            }
        }

        STUDENTPROG studProg = new STUDENTPROG();

        private void Grenada_Team_Progress_Report_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student_progress` WHERE `Swim Team/s`='Sailfish and Grenada' OR 'Grenfin and Grenada' OR 'Dolphin and Grenada'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = studProg.getStudentsProgress(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student_progress` WHERE `Swim Team/s`='Sailfish and Grenada' OR 'Grenfin and Grenada' OR 'Dolphin and Grenada'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = studProg.getStudentsProgress(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Progress_Report addProgRep = new Progress_Report();
            addProgRep.Show();
        }
    }
}
