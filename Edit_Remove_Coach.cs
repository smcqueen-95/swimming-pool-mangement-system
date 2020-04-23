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
    public partial class Edit_Remove_Coach : Form
    {
        public Edit_Remove_Coach()
        {
            InitializeComponent();
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

        COACHES coach = new COACHES();

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
                string address = textBoxAddress.Text;
                string phone = textBoxPhone.Text;
                string email = textBoxEmail.Text;
                string steam = textBoxSwm.Text;


                //checking the age of the coach
                //the coach must be between 16 - 45
                int born_year = dateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;

                if (((this_year - born_year) < 16) || ((this_year - born_year) > 45))
                {
                    MessageBox.Show("The Coach's Age Must be Between 16 and 45 Years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    if (coach.updateCoach(id, fname, lname, gender, bdate, age, address, phone, email, steam))
                    {
                        MessageBox.Show("Coach Information Updated", "Edit Coach", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Coach", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                else
                {
                    MessageBox.Show("Please Check The Information Again. There Are Empty Fields", "Edit Coach", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Coach Was Not Selected", "Edit Coach", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                //Show a confirmation message before deleting the swimmer
               if (MessageBox.Show("Are You Sure You Want to Delete This Coach", "Delete Coach", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (coach.deleteCoach(id))
                    {
                        MessageBox.Show("Coach Deleted", "Deleted Coach", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //clear fields
                        textBoxId.Text = "";
                        textBoxFname.Text = "";
                        textBoxLname.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        textBoxAge.Text = "";
                        textBoxAddress.Text = "";
                        textBoxPhone.Text = "";
                        textBoxEmail.Text = "";
                        textBoxSwm.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Coach Not Deleted!", "Delete Coach", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Coach Was Not Selected", "Delete Coach", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //Search coaches by id
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `Address`, `Phone Number`, `Email`, `Swim Team/s` FROM `coaches` WHERE `ID`=" + id);

                DataTable table = coach.getCoaches(command);

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
                    textBoxAddress.Text = table.Rows[0]["Address"].ToString();
                    textBoxPhone.Text = table.Rows[0]["Phone Number"].ToString();
                    textBoxEmail.Text = table.Rows[0]["Email"].ToString();
                    textBoxSwm.Text = table.Rows[0]["Swim Team/s"].ToString();

                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Coach's ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan tSpan = to - from;
            double days = tSpan.TotalDays;
            textBoxAge.Text = (days / 365).ToString("0");

        }

        private void Edit_Remove_Coach_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
    }
}
