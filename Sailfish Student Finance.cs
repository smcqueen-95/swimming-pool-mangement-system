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
    public partial class Sailfish_Student_Finance : Form
    {
        public Sailfish_Student_Finance()
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
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            else if (labelUser.Text == "Sailfish Team Leader")
            {
                this.Hide();
                Sailfish_Dashboard sailfishDash = new Sailfish_Dashboard();
                sailfishDash.Show();
            }
        }

        STUDENTFINANCE studFinance = new STUDENTFINANCE();

        private void Sailfish_Student_Finance_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student_finance` WHERE `Swim Team/s`='Sailfish'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = studFinance.getStudentsFinance(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student_finance` WHERE `Swim Team/s`='Sailfish'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = studFinance.getStudentsFinance(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Finance studFinance = new Student_Finance();
            studFinance.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Remove_Student_Finance editStudFinance = new Edit_Remove_Student_Finance();
            editStudFinance.Show();
        }
    }
}
