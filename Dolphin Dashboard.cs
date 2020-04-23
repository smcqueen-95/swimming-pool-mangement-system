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
    public partial class Dolphin_Dashboard : Form
    {
        public Dolphin_Dashboard()
        {
            InitializeComponent();
        }

        private void DolphinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin dolphin = new Dolphin();
            dolphin.Show();
        }

        private void Dolphin_Dashboard_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void coachesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Coaches dolphinCoach = new Dolphin_Coaches();
            dolphinCoach.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_CoachAtten dolphinCoachAtten = new Dolphin_CoachAtten();
            dolphinCoachAtten.Show();
        }

        private void financesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Student_Finance dolStudFinance = new Dolphin_Student_Finance();
            dolStudFinance.Show();
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
