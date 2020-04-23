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
    public partial class CoachesForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");

        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public CoachesForm()
        {
            InitializeComponent();
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

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_New_Coach newCoachF = new Add_New_Coach();
            newCoachF.Show();
        }

        COACHES coach = new COACHES();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM coaches WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `Address`, `Phone Number`, `Email`, `Swim Team/s`) like '%" + valueToSearch + "%'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void CoachesForm_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;

            labelUser.Text = GLOBAL.userType;

            searchData("");
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //displaying the selected student in a new form to edit/remove
            Edit_Remove_Coach editRemoveCoachF = new Edit_Remove_Coach();
            editRemoveCoachF.textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editRemoveCoachF.textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editRemoveCoachF.textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            //gender
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Female")
            {
                editRemoveCoachF.radioButtonFemale.Checked = true;
            }

            editRemoveCoachF.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            editRemoveCoachF.textBoxAge.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            editRemoveCoachF.textBoxAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            editRemoveCoachF.textBoxPhone.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            editRemoveCoachF.textBoxEmail.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            editRemoveCoachF.textBoxSwm.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            editRemoveCoachF.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //Refreshing the Datagridview data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `coaches`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = coach.getCoaches(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_Remove_Coach editRemCoachF = new Edit_Remove_Coach();
            editRemCoachF.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCoachAtten_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Coach_Attendance addCoachAtten = new Add_Coach_Attendance();
            addCoachAtten.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }
    }
}
