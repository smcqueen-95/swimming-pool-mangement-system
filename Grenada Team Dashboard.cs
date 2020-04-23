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
    public partial class Grenada_Team_Dashboard : Form
    {
        public Grenada_Team_Dashboard()
        {
            InitializeComponent();
        }

        private void grenadaBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Swim_Team grenSwim = new Grenada_Swim_Team();
            grenSwim.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void coachesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Team_Coaches grenTeamCoaches = new Grenada_Team_Coaches();
            grenTeamCoaches.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Team_CoachAtten grenTeamCoachAtten = new Grenada_Team_CoachAtten();
            grenTeamCoachAtten.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Team_Progress_Report grenTeamProgrep = new Grenada_Team_Progress_Report();
            grenTeamProgrep.Show();
        }

        private void aintenanceBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pool_Maintenance_List poolMainList = new Pool_Maintenance_List();
            poolMainList.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.Show();
        }
    }
}
