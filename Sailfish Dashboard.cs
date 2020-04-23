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
    public partial class Sailfish_Dashboard : Form
    {
        public Sailfish_Dashboard()
        {
            InitializeComponent();
        }

        private void sailfishBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Sailfish sailfish = new Sailfish();
            sailfish.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void coachesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish_Coaches sailfishCoach = new Sailfish_Coaches();
            sailfishCoach.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish_CoachAtten sailfishCoachAtten = new Sailfish_CoachAtten();
            sailfishCoachAtten.Show();
        }

        private void Sailfish_Dashboard_Load(object sender, EventArgs e)
        {
            
            labelUser.Text = GLOBAL.userType;
        }

        private void financesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish_Student_Finance sailfishStudFin = new Sailfish_Student_Finance();
            sailfishStudFin.Show();
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
