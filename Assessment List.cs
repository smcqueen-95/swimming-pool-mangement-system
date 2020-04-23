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
    public partial class Assessment_List : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Assessment_List()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Assessment addAss = new Add_Assessment();
            addAss.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }

        ASSESSMENT assessment = new ASSESSMENT();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM assessment WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Age`, `Date`, `Swim Team/s`, `Swim Group`, `Grade`) like '%" + valueToSearch + "%'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Assessment_List_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `assessment`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = assessment.getAssessments(command);
            dataGridView1.AllowUserToAddRows = false;

            searchData("");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `assessment`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = assessment.getAssessments(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Hide();
                Swimmer_List swimList = new Swimmer_List();
                swimList.Show();
            }

        }

    }
}
