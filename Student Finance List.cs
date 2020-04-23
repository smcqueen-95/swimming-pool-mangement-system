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
    public partial class Student_Finance_List : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Student_Finance_List()
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
        }

        STUDENTFINANCE studFinance = new STUDENTFINANCE();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM student_finance WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Swim Team/s`, `Swim Group`, `Term 1`, `Term 2`, `Term 3`) like '%" + valueToSearch + "%'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Student_Finance_List_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student_finance`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = studFinance.getStudentsFinance(command);
            dataGridView1.AllowUserToAddRows = false;

            searchData("");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student_finance`");
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }
    }
}
