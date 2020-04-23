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
    public partial class Add_New_Coach : Form
    {
        public Add_New_Coach()
        {
            InitializeComponent();
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
                this.Hide();
                CoachesForm coachF = new CoachesForm();
                coachF.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish_Coaches sailfishCoach = new Sailfish_Coaches();
                sailfishCoach.Show();
            }

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Add Coach 
            COACHES coach = new COACHES();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            DateTime bdate = dateTimePicker1.Value;
            string age = textBoxAge.Text;
            string address = textBoxAddress.Text;
            string phone = textBoxPhone.Text;
            string email = textBoxEmail.Text;
            string steam = textBoxSwm.Text;
            

            //checking the age of the coach
            //the swimmer must be between 16 - 45
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if (((this_year - born_year) < 16) || ((this_year - born_year) > 45))
            {
                MessageBox.Show("The Coach's Age Must be Between 16 and 45 Years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                if (coach.insertCoach(fname, lname, gender, bdate, age, address, phone, email, steam))
                {
                    MessageBox.Show("New Coach Added", "Add Coach", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Coach", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("Please Check The Information Again. There Are Empty Fields", "Add Coach", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //create a function to verify data
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxAge.Text.Trim() == "") ||
                (textBoxAddress.Text.Trim() == "") ||
                (textBoxPhone.Text.Trim() == "") ||
                (textBoxEmail.Text.Trim() == "") ||
                (textBoxSwm.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan tSpan = to - from;
            double days = tSpan.TotalDays;
            textBoxAge.Text = (days / 365).ToString("0");

        }

        private void Add_New_Coach_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
    }

    
}

