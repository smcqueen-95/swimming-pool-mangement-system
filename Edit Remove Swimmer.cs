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
    public partial class Edit_Remove_Swimmer : Form
    {
        public Edit_Remove_Swimmer()
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

        SWIMMER swimmer = new SWIMMER();

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
                (textBoxPnum.Text.Trim() == "") ||
                (textBoxPemail.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            //Update the selected student
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
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
                string swimg = textBoxGroup.Text;
                string pname = textBoxPname.Text;
                string paddress = textBoxPaddress.Text;
                string pnum = textBoxPnum.Text;
                string pemail = textBoxPemail.Text;



                //checking the age of the swimmer
                //the coach must be between 2 - 4
                int born_year = dateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;

                if (((this_year - born_year) < 2) || ((this_year - born_year) > 19))
                {
                    MessageBox.Show("The Swimmer's Age Must be Between 2 and 19 Years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    if (swimmer.updateSwimmer(id, fname, lname, gender, bdate, age, school, medical, swimt, swimg, pname, paddress, pnum, pemail))
                    {
                        MessageBox.Show("Swimmer Information Updated", "Edit Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                else
                {
                    MessageBox.Show("Please Check The Information Again. There Are Empty Fields", "Edit Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Swimmer Was Not Selected", "Edit Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                //Show a confirmation message before deleting the swimmer
                if (MessageBox.Show("Are You Sure You Want to Delete This Swimmer", "Delete Swimmer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (swimmer.deleteSwimmer(id))
                    {
                        MessageBox.Show("Swimmer Deleted", "Deleted Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //clear fields
                        textBoxId.Text = "";
                        textBoxFname.Text = "";
                        textBoxLname.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        textBoxAge.Text = "";
                        textBoxSchool.Text = "";
                        textBoxMedical.Text = "";
                        textBoxSwmT.Text = "";
                        textBoxGroup.Text = "";
                        textBoxPname.Text = "";
                        textBoxPaddress.Text = "";
                        textBoxPnum.Text = "";
                        textBoxPemail.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Swimmer Not Deleted!", "Delete Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Swimmer Was Not Selected", "Delete Swimmer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //Search coaches by id
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `School`, `Medical`, `Swim Team/s`, `Swim Group`, `Parent/s Name`, `Parent/s Address`, `Parent/s Number`, `Parent Email` FROM `swimmers` WHERE `ID`=" + id);

                DataTable table = swimmer.getSwimmers(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["First Name"].ToString();
                    textBoxLname.Text = table.Rows[0]["Last Name"].ToString();
                    //gender
                    if (table.Rows[0]["Gender"].ToString() == "Female")
                    {
                        radioButtonFemale.Checked = true;
                    }
                    else
                    {
                        radioButtonMale.Checked = true;
                    }
                    dateTimePicker1.Value = (DateTime)table.Rows[0]["Birth Date"];
                    textBoxAge.Text = table.Rows[0]["Age"].ToString();
                    textBoxSchool.Text = table.Rows[0]["School"].ToString();
                    textBoxMedical.Text = table.Rows[0]["Medical"].ToString();
                    textBoxSwmT.Text = table.Rows[0]["Swim Team/s"].ToString();
                    textBoxGroup.Text = table.Rows[0]["Swim Group"].ToString();
                    textBoxPname.Text = table.Rows[0]["Parent/s Name"].ToString();
                    textBoxPaddress.Text = table.Rows[0]["Parent/s Address"].ToString();
                    textBoxPnum.Text = table.Rows[0]["Parent/s Number"].ToString();
                    textBoxPemail.Text = table.Rows[0]["Parent Email"].ToString();

                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Swimmer's ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Edit_Remove_Swimmer_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
    }
}
