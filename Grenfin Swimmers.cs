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
    public partial class Grenfin_Swimmers : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Grenfin_Swimmers()
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
                Grenfin grenfin = new Grenfin();
                grenfin.Show();
            }
            else if (labelUser.Text == "Grenfin Team Leader")
            {
                this.Hide();
                Grenfin grenfin = new Grenfin();
                grenfin.Show();
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
            Edit_Remove_Swimmer editRemoveSwim = new Edit_Remove_Swimmer();
            editRemoveSwim.Show();
        }

        SWIMMER swimmer = new SWIMMER();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM `swimmers` WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `School`, `Medical`, `Swim Team/s`, `Swim Group`, `Parent/s Name`, `Parent/s Address`, `Parent/s Number`, `Parent Email`) like '%" + valueToSearch + "%' AND `Swim Team/s`= 'Grenfin'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = swimmer.getSwimmers(command);
        }

        private void Grenfin_Swimmers_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers` WHERE `Swim Team/s`='Grenfin'");
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers` WHERE `Swim Team/s`='Grenfin'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = swimmer.getSwimmers(command);
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
