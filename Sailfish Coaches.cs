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
    public partial class Sailfish_Coaches : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Sailfish_Coaches()
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

        COACHES coach = new COACHES();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM `coaches` WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `Address`, `Phone Number`, `Email`, `Swim Team/s`) like '%" + valueToSearch + "%' AND `Swim Team/s`= 'Sailfish'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = coach.getCoaches(command);
        }

        private void Sailfish_Coaches_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches` WHERE `Swim Team/s`='Sailfish'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
            
            labelUser.Text = GLOBAL.userType;

           searchData("");
        }
        
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches` WHERE `Swim Team/s`='Sailfish'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Remove_Coach editRemoveCoach = new Edit_Remove_Coach();
            editRemoveCoach.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }
    }
}
