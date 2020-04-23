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
    public partial class Add_Assessment : Form
    {
        public Add_Assessment()
        {
            InitializeComponent();
        }
        
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Hide();
                Assessment_List assList = new Assessment_List();
                assList.Show();
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

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        SWIMMER swimmer = new SWIMMER();
       
        //create a function to verify data
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxAge.Text.Trim() == "") ||
                (textBoxSwimT.Text.Trim() == "") ||
                (textBoxSwimG.Text.Trim() == ""))

            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            //Search coaches by id
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Age`, `Swim Team/s`, `Swim Group` FROM `swimmers` WHERE `ID`=" + id);

                DataTable table = swimmer.getSwimmers(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["First Name"].ToString();
                    textBoxLname.Text = table.Rows[0]["Last Name"].ToString();
                    textBoxAge.Text = table.Rows[0]["Age"].ToString();
                    textBoxSwimT.Text = table.Rows[0]["Swim Team/s"].ToString();
                    textBoxSwimG.Text = table.Rows[0]["Swim Group"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Swimmer's ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //Add Prebeginner 
            ASSESSMENT assessment = new ASSESSMENT();
            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string age = textBoxAge.Text;
            DateTime date = dateTimePicker2.Value;
            string swimT = textBoxSwimT.Text;
            string swimG = textBoxSwimG.Text;
            string grade = textBoxGrade.Text;
            


            if (verif())
            {
                if (assessment.insertAssessment(fname, lname, age, date, swimT, swimG, grade))
                {
                    MessageBox.Show("Assessment Added", "Add Assessment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Assessment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("Please Check The Information Again. There Are Empty Fields", "Add Assessment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Add_Assessment_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
    }
}
