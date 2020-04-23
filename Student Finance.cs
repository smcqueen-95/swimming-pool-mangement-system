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
    public partial class Student_Finance : Form
    {
        public Student_Finance()
        {
            InitializeComponent();
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
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            else if (labelUser.Text == "Grenfin Team Leader")
            {
                this.Hide();
                Grenfin grenfin = new Grenfin();
                grenfin.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish sailfish = new Sailfish();
                sailfish.Show();
            }
            else if (labelUser.Text == "Dolphin Team Leader")
            {
                this.Hide();
                Dolphin dolphin = new Dolphin();
                dolphin.Show();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Student_Finance_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }

        //create a function to verify data
        bool verif()
        {
            if ((textBoxFname.Text.Trim() == "") ||
                (textBoxLname.Text.Trim() == "") ||
                (textBoxSwmT.Text.Trim() == "") ||
                (textBoxSwimG.Text.Trim() == "") ||
                (textBoxTerm1.Text.Trim() == "") ||
                (textBoxTerm2.Text.Trim() == "") ||
                (textBoxTerm3.Text.Trim() == ""))

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
            STUDENTFINANCE studFinance = new STUDENTFINANCE();

            string fname = textBoxFname.Text;
            string lname = textBoxLname.Text;
            string swimT = textBoxSwmT.Text;
            string swimG = textBoxSwimG.Text;
            string term1 = textBoxTerm1.Text;
            string term2 = textBoxTerm2.Text;
            string term3 = textBoxTerm3.Text;


            if (verif())
            {
                if (studFinance.insertStudentFinance(fname, lname, swimT, swimG, term1, term2, term3))
                {
                    MessageBox.Show("Student Finance Added", "Add Student''s Finance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student''s Finance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            SWIMMER swimmer = new SWIMMER();
            //Search coaches by id
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Swim Team/s`, `Swim Group` FROM `swimmers` WHERE `ID`=" + id);

                DataTable table = swimmer.getSwimmers(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["First Name"].ToString();
                    textBoxLname.Text = table.Rows[0]["Last Name"].ToString();
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
