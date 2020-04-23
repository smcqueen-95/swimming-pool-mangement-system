using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Swimming_Pool_Management_System
{
    public partial class Add_Coach_Attendance : Form
    {
        public Add_Coach_Attendance()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }


        //create a function to verify data
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxSwmT.Text.Trim() == "") ||
                (textBoxArrival.Text.Trim() == "" ) ||
                (textBoxSession.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            COACHATTENDANCE coachAtten = new COACHATTENDANCE();

            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            DateTime date = dateTimePicker1.Value;
            string swimT = textBoxSwmT.Text;
            string arrTime = textBoxArrival.Text;
            string sessTaught = textBoxSession.Text;

            if (verif())
            {
                if (coachAtten.insertCoachAtten(fname, lname, date, swimT, arrTime, sessTaught))
                {
                    MessageBox.Show("Coach Attendance Added", "Add Coach Attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Coach Attendance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Hide();
                Coach_Attendance_List coachAttenList = new Coach_Attendance_List();
                coachAttenList.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish_CoachAtten sailfishCoachAtten = new Sailfish_CoachAtten();
                sailfishCoachAtten.Show();
            }
        }

        private void Add_Coach_Attendance_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            COACHES coach = new COACHES();
            //Search coaches by id
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Swim Team/s` FROM `coaches` WHERE `ID`=" + id);

                DataTable table = coach.getCoaches(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["First Name"].ToString();
                    textBoxLname.Text = table.Rows[0]["Last Name"].ToString();
                    textBoxSwmT.Text = table.Rows[0]["Swim Team/s"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Swimmer's ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
