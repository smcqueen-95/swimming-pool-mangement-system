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
    public partial class Edit_Remove_Student_Finance : Form
    {
        public Edit_Remove_Student_Finance()
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
                this.Hide();
                Student_Finance_List studFinance = new Student_Finance_List();
                studFinance.Show();
            }
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
        STUDENTFINANCE studFinance = new STUDENTFINANCE();

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                string fname = textBoxFname.Text;
                string lname = textBoxLname.Text;
                string swimT = textBoxSwmT.Text;
                string swimG = textBoxSwimG.Text;
                string term1 = textBoxTerm1.Text;
                string term2 = textBoxTerm2.Text;
                string term3 = textBoxTerm3.Text;


                if (verif())
                {
                    if (studFinance.updateStudentFinance(id, fname, lname, swimT, swimG, term1, term2, term3))
                    {
                        MessageBox.Show("Student's Finance Updated", "Edit Student Finance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update Student Finance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Swimmer Was Not Selected", "Edit Student Finance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                MySqlCommand command = new MySqlCommand("SELECT `ID`, `First Name`, `Last Name`, `Swim Team/s`, `Swim Group`, `Term 1`, `Term 2`, `Term 3` FROM `student_finance` WHERE `ID`=" + id);

                DataTable table = studFinance.getStudentsFinance(command);

                if (table.Rows.Count > 0)
                {
                    textBoxFname.Text = table.Rows[0]["First Name"].ToString();
                    textBoxLname.Text = table.Rows[0]["Last Name"].ToString();
                    textBoxSwmT.Text = table.Rows[0]["Swim Team/s"].ToString();
                    textBoxSwimG.Text = table.Rows[0]["Swim Group"].ToString();
                    textBoxTerm1.Text = table.Rows[0]["Term 1"].ToString();
                    textBoxTerm2.Text = table.Rows[0]["Term 2"].ToString();
                    textBoxTerm3.Text = table.Rows[0]["Term 3"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Swimmer's ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Edit_Remove_Student_Finance_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;
        }
    }
}
