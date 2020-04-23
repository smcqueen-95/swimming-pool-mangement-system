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
    public partial class Grenada_Swim_Team : Form
    {
        public Grenada_Swim_Team()
        {
            InitializeComponent();
        }

        private void learnToSwimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Team grenadaTeamList = new Grenada_Team();
            grenadaTeamList.Show();
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
            else if (labelUser.Text == "Grenada Team Leader")
            {
                this.Hide();
                Grenada_Team_Dashboard grenadaDash = new Grenada_Team_Dashboard();
                grenadaDash.Show();
            }
        }

        private void Grenada_Swim_Team_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }

        private void progressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Team_Progress_Report grenProgRep = new Grenada_Team_Progress_Report();
            grenProgRep.Show();
        }
    }
}
