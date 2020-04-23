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
    public partial class Coach_Attendance_List : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Coach_Attendance_List()
        {
            InitializeComponent();
        }

        COACHATTENDANCE coachAtten = new COACHATTENDANCE();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM coaches_atten WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Date`, `Swim Team/s`, `Arrival Time`, `Session/s Taught`) like '%" + valueToSearch + "%'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Coach_Attendance_List_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches_atten`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coachAtten.getCoachesAtten(command);
            dataGridView1.AllowUserToAddRows = false;

            labelUser.Text = GLOBAL.userType;

            searchData("");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //Refreshing the Datagridview data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches_atten`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coachAtten.getCoachesAtten(command);
            dataGridView1.AllowUserToAddRows = false;
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }
    }
}
