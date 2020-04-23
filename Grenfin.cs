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

        private void preBeginnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Prebeginner_List grenPreBegList = new Grenfin_Prebeginner_List();
            grenPreBegList.Show();
        }

        private void beginnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Beginner_List grenBegList = new Grenfin_Beginner_List();
            grenBegList.Show();
        }

        private void advanceBeginnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AdvBeginner_List grenAdvBegList = new Grenfin_AdvBeginner_List();
            grenAdvBegList.Show();
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Intermediate_List grenIntList = new Grenfin_Intermediate_List();
            grenIntList.Show();
        }

        private void juniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Junior_List grenJunList = new Grenfin_Junior_List();
            grenJunList.Show();
        }

        private void advanceJuniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AdvJunior_List grenAdvJunList = new Grenfin_AdvJunior_List();
            grenAdvJunList.Show();
        }

        private void seniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Senior_List grenSenList = new Grenfin_Senior_List();
            grenSenList.Show();
        }

        private void advanceSeniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AdvSenior_List grenAdvSenList = new Grenfin_AdvSenior_List();
            grenAdvSenList.Show();
        }

        private void preBeginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssPrebeginner_List grenAssPreList = new Grenfin_AssPrebeginner_List();
            grenAssPreList.Show();
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssBeginner_List grenAssBegList = new Grenfin_AssBeginner_List();
            grenAssBegList.Show();
        }

        private void advanceBeginnersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssAdvBeginner_List grenAssAdvBegList = new Grenfin_AssAdvBeginner_List();
            grenAssAdvBegList.Show();
        }

        private void intermediateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssIntermediate_List grenAssIntList = new Grenfin_AssIntermediate_List();
            grenAssIntList.Show();
        }

        private void juniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssJunior_List grenAssJunList = new Grenfin_AssJunior_List();
            grenAssJunList.Show();
        }

        private void advanceJuniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssAdvJunior_List grenAssAdvJunList = new Grenfin_AssAdvJunior_List();
            grenAssAdvJunList.Show();
        }

        private void seniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssSenior_List grenAssSenList = new Grenfin_AssSenior_List();
            grenAssSenList.Show();
        }

        private void advanceSeniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_AssAdvSenior_List grenAssAdvSenList = new Grenfin_AssAdvSenior_List();
            grenAssAdvSenList.Show();
        }

        private void progressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin_Progress_Report grenfinStudProgList = new Grenfin_Progress_Report();
            grenfinStudProgList.Show();
        }
    }
}
