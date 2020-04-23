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
    public partial class Dolphin_Assessments : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Dolphin_Assessments()
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
                Dolphin dolphin = new Dolphin();
                dolphin.Show();
            }
            else if (labelUser.Text == "Dolphin Team Leader")
            {
                this.Hide();
                Dolphin dolphin = new Dolphin();
                dolphin.Show();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }

        ASSESSMENT assessment = new ASSESSMENT();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM `assessment` WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Age`, `Date`, `Swim Team/s`, `Swim Group`, `Grade`) like '%" + valueToSearch + "%' AND `Swim Team/s`= 'Dolphin'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = assessment.getAssessments(command);
        }

        private void Dolphin_Assessments_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `assessment` WHERE `Swim Team/s`='Dolphin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = assessment.getAssessments(command);
            dataGridView1.AllowUserToAddRows = false;

            labelUser.Text = GLOBAL.userType;
            searchData("");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `assessment` WHERE `Swim Team/s`='Dolphin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = assessment.getAssessments(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Assessment addAss = new Add_Assessment();
            addAss.Show();
        }
    }
}
