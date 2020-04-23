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
    public partial class Grenfin : Form
    {
        public Grenfin()
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
            else if (labelUser.Text == "Grenfin Team Leader")
            {
                this.Hide();
                Grenfin_Dashboard grenfinDash = new Grenfin_Dashboard();
                grenfinDash.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Grenfin_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
        

        private void progressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Progress_Report grenfinStudProgList = new Grenfin_Progress_Report();
            grenfinStudProgList.Show();
        }

        private void learnToSwimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Swimmers grenfinSwim = new Grenfin_Swimmers();
            grenfinSwim.Show();
        }

        private void assesmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Assessments grenfinAss = new Grenfin_Assessments();
            grenfinAss.Show();
        }
    }
}
