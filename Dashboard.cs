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
    public partial class Dashboard : Form
    {
       
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Green;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void coachesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CoachesForm coachesList = new CoachesForm();
            coachesList.Show();
        }

        private void sailfishBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sailfish sailfishF = new Sailfish();
            sailfishF.Show();
        }

        private void grenfinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenfin grenfinF = new Grenfin();
            grenfinF.Show();
        }

        private void DolphinBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dolphin dolphinF = new Dolphin();
            dolphinF.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Coach_Attendance_List coachAttenList = new Coach_Attendance_List();
            coachAttenList.Show();
        }

        private void allSwimmersBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Swimmer_List swimmerList = new Swimmer_List();
            swimmerList.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
            label4.Text = GLOBAL.userType;
        }

        private void grenadaBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grenada_Team grenadaTeam = new Grenada_Team();
            grenadaTeam.Show();
        }

        private void financesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Finance_List studFinList = new Student_Finance_List();
            studFinList.Show();
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
