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
    public partial class Grenfin_Dashboard : Form
    {
        public Grenfin_Dashboard()
        {
            InitializeComponent();
        }

        private void financesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Student_Finance grenfinStudFin = new Grenfin_Student_Finance();
            grenfinStudFin.Show();
        }

        private void coachesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Coaches grenfinCoach = new Grenfin_Coaches();
            grenfinCoach.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_CoachAtten grenCoachAtten = new Grenfin_CoachAtten();
            grenCoachAtten.Show();
        }

        private void grenfinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin grenfin = new Grenfin();
            grenfin.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aintenanceBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pool_Maintenance_List poolMainList = new Pool_Maintenance_List();
            poolMainList.Show();
        }

        private void Grenfin_Dashboard_Load(object sender, EventArgs e)
        {
            label4.Text = GLOBAL.userType;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.Show();
        }
    }
}
