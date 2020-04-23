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
    public partial class Sailfish : Form
    {

        public Sailfish()
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
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish_Dashboard sailfishDash = new Sailfish_Dashboard();
                sailfishDash.Show();
            }
        
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }   
        
        private void progressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish_Progress_Report sailfishProgRep = new Sailfish_Progress_Report();
            sailfishProgRep.Show();
        }

        private void Sailfish_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
        
        private void learnToSwimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish_Swimmers sailfishSwim = new Sailfish_Swimmers();
            sailfishSwim.Show();
        }

        private void assesmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish_Assessments sailfishAss = new Sailfish_Assessments();
            sailfishAss.Show();
        }
    }
}
