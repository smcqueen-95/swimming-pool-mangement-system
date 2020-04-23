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

        private void preBeginnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Prebeginner_List dolphinPreList = new Dolphin_Prebeginner_List();
            dolphinPreList.Show();
        }

        private void beginnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Beginner_List dolBegList = new Dolphin_Beginner_List();
            dolBegList.Show();
        }

        private void advanceBeginnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AdvBeginner_List dolphinAdvBegList = new Dolphin_AdvBeginner_List();
            dolphinAdvBegList.Show();
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Intermediate_List dolphinIntList = new Dolphin_Intermediate_List();
            dolphinIntList.Show();
        }

        private void juniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Junior_List dolphinJunList = new Dolphin_Junior_List();
            dolphinJunList.Show();
        }

        private void advanceJuniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AdvJunior_List dolphinAdvJunList = new Dolphin_AdvJunior_List();
            dolphinAdvJunList.Show();
        }

        private void seniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Senior_List dolphinSenList = new Dolphin_Senior_List();
            dolphinSenList.Show();
        }

        private void advanceSeniorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AdvSenior_List dolphinAdvSenList = new Dolphin_AdvSenior_List();
            dolphinAdvSenList.Show();
        }

        private void preBeginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssPrebeginner_List dolAssPreList = new Dolphin_AssPrebeginner_List();
            dolAssPreList.Show();
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssBeginner_List dolAssBegList = new Dolphin_AssBeginner_List();
            dolAssBegList.Show();
        }

        private void advanceBeginnersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssAdvBeginner_List dolAssAdvBegList = new Dolphin_AssAdvBeginner_List();
            dolAssAdvBegList.Show();
        }

        private void intermediateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssIntermediate_List dolAssIntList = new Dolphin_AssIntermediate_List();
            dolAssIntList.Show();
        }

        private void juniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssJunior_List dolAssJunList = new Dolphin_AssJunior_List();
            dolAssJunList.Show();
        }

        private void advanceJuniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssAdvJunior_List dolAssAdvJunList = new Dolphin_AssAdvJunior_List();
            dolAssAdvJunList.Show();
        }

        private void seniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssSenior_List dolAssSenList = new Dolphin_AssSenior_List();
            dolAssSenList.Show();
        }

        private void advanceSeniorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_AssAdvSenior_List dolAssAdvSenList = new Dolphin_AssAdvSenior_List();
            dolAssAdvSenList.Show();
        }

        private void progressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin_Progress_Report dolphinProgrep = new Dolphin_Progress_Report();
            dolphinProgrep.Show();
        }
    }
}
