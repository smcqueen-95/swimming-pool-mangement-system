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
    public partial class Dolphin_Swimmers : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Dolphin_Swimmers()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Remove_Swimmer editRemoveSwimmer = new Edit_Remove_Swimmer();
            editRemoveSwimmer.Show();
        }

        SWIMMER swimmer = new SWIMMER();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM `swimmers` WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `School`, `Medical`, `Swim Team/s`, `Swim Group`, `Parent/s Name`, `Parent/s Address`, `Parent/s Number`, `Parent Email`) like '%" + valueToSearch + "%' AND `Swim Team/s`= 'Dolphin'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = swimmer.getSwimmers(command);
        }

        private void Dolphin_Swimmers_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers` WHERE `Swim Team/s`='Dolphin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = swimmer.getSwimmers(command);
            dataGridView1.AllowUserToAddRows = false;

            labelUser.Text = GLOBAL.userType;

            searchData("");
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers` WHERE `Swim Team/s`='Dolphin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = swimmer.getSwimmers(command);
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
