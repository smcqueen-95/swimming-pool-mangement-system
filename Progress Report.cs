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
    public partial class Progress_Report : Form
    {
        public Progress_Report()
        {
            InitializeComponent();
        }

        private void Progress_Report_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
        //create a function to verify data
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxAge.Text.Trim() == "") ||
                (textBoxSwmT.Text.Trim() == "") ||
                (textBoxSwimG.Text.Trim() == "") ||
                (comboBox1.Text.Trim() == "") ||
                (textBoxTime.Text.Trim() == "") ||
                (textBoxComment.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }

        STUDENTPROG studProg = new STUDENTPROG();

        private void addBtn_Click(object sender, EventArgs e)
        {
            

            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string age = textBoxAge.Text;
            string swimT = textBoxSwmT.Text;
            string swimG = textBoxSwimG.Text;
            DateTime date = dateTimePicker1.Value;
            string swimRace = comboBox1.Text;
            string timeRace = textBoxTime.Text;
            string comment = textBoxComment.Text;


            if (verif())
            {
                if (studProg.insertStudentProgress(fname, lname, age, swimT, swimG, date, swimRace, timeRace, comment))
                {
                    MessageBox.Show("Progress Report Added", "Add Student's Progress Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student's Progress Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Close();
                Progress_Report_List progRepList = new Progress_Report_List();
                progRepList.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Close();
                Sailfish_Progress_Report sailfishProgRep = new Sailfish_Progress_Report();
                sailfishProgRep.Show();
            }
            else if (labelUser.Text == "Grenfin Team Leader")
            {
                this.Close();
                Grenfin_Progress_Report GrenProgrep = new Grenfin_Progress_Report();
                GrenProgrep.Show();
            }
            else if (labelUser.Text == "Dolphin Team Leader")
            {
                this.Close();
                Dolphin_Progress_Report dolphinProgRep = new Dolphin_Progress_Report();
                dolphinProgRep.Show();
            }
            else if (labelUser.Text == "Grenada Team Leader")
            {
                this.Close();
                Grenada_Team_Progress_Report grenProgRep = new Grenada_Team_Progress_Report();
                grenProgRep.Show();
            }

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            SWIMMER swimmer = new SWIMMER();
            //Search coaches by id
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Age`, `Swim Team/s`, `Swim Group` FROM `swimmers` WHERE `ID`=" + id);

                DataTable table = studProg.getStudentsProgress(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["First Name"].ToString();
                    textBoxLname.Text = table.Rows[0]["Last Name"].ToString();
                    textBoxAge.Text = table.Rows[0]["Age"].ToString();
                    textBoxSwmT.Text = table.Rows[0]["Swim Team/s"].ToString();
                    textBoxSwimG.Text = table.Rows[0]["Swim Group"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Swimmer's ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
