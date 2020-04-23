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
    public partial class Add_Swimmer : Form
    {
        public Add_Swimmer()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Hide();
                Swimmer_List swimmerList = new Swimmer_List();
                swimmerList.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish sailfish = new Sailfish();
                sailfish.Show();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Add Prebeginner 
            SWIMMER swimmer = new SWIMMER();

            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            DateTime bdate = dateTimePicker1.Value;
            string age = textBoxAge.Text;
            string school = textBoxSchool.Text;
            string medical = textBoxMedical.Text;
            string swimt = textBoxSwmT.Text;
            string swiml = textBoxGroup.Text;
            string pname = textBoxPname.Text;
            string paddress = textBoxPaddress.Text;
            string pnum = textBoxPnum.Text;
            string pemail = textBoxPemail.Text;


            //checking the age of the coach
            //the swimmer must be between 2 - 4
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 2) || ((this_year - born_year) > 19))
            {
                MessageBox.Show("The Swimmer's Age Must be Between 2 and 19 Years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                if (swimmer.insertSwimmer(fname, lname, gender, bdate, age, school, medical, swimt, swiml, pname, paddress, pnum, pemail))
                {
                    MessageBox.Show("New Swimmer Added", "Add Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("Please Check The Information Again. There Are Empty Fields", "Add Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //create a function to verify data
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxAge.Text.Trim() == "") ||
                (textBoxSchool.Text.Trim() == "") ||
                (textBoxMedical.Text.Trim() == "") ||
                (textBoxSwmT.Text.Trim() == "") ||
                (textBoxGroup.Text.Trim() == "") ||
                (textBoxPname.Text.Trim() == "") ||
                (textBoxPaddress.Text.Trim() == "") ||
                (textBoxPnum.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_PreBeginner_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan tSpan = to - from;
            double days = tSpan.TotalDays;
            textBoxAge.Text = (days / 365).ToString("0");
        }
    }
}
