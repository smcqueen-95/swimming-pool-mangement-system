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
    public partial class Dolphin : Form
    {
        public Dolphin()
        {
            InitializeComponent();
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
                this.Close();
                Dolphin_Dashboard dolphinDash = new Dolphin_Dashboard();
                dolphinDash.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Dolphin_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }

        private void progressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Progress_Report dolphinProgrep = new Dolphin_Progress_Report();
            dolphinProgrep.Show();
        }

        private void learnToSwimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Swimmers dolphinSwim = new Dolphin_Swimmers();
            dolphinSwim.Show();
        }

        private void assesmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Assessments dolphinAss = new Dolphin_Assessments();
            dolphinAss.Show();
        }
    }
}
