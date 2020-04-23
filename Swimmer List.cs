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
    public partial class Swimmer_List : Form
    {

       MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");
       
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public Swimmer_List()
        {
            InitializeComponent();
        }

        SWIMMER swimmer = new SWIMMER();

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM swimmers WHERE CONCAT(`ID`, `First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `School`, `Medical`, `Swim Team/s`, `Swim Group`, `Parent/s Name`, `Parent/s Address`, `Parent/s Number`, `Parent Email`) like '%" + valueToSearch + "%'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxSearch.Text.ToString();
            searchData(valueToSearch);
        }

        private void Swimmer_List_Load(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers`");
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = swimmer.getSwimmers(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //displaying the selected student in a new form to edit/remove
            Edit_Remove_Swimmer editRemoveSwimF = new Edit_Remove_Swimmer();
            editRemoveSwimF.textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editRemoveSwimF.textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editRemoveSwimF.textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            //gender
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Female")
            {
                editRemoveSwimF.radioButtonFemale.Checked = true;
            }

            editRemoveSwimF.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
            editRemoveSwimF.textBoxAge.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            editRemoveSwimF.textBoxSchool.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            editRemoveSwimF.textBoxMedical.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            editRemoveSwimF.textBoxSwmT.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            editRemoveSwimF.textBoxGroup.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            editRemoveSwimF.textBoxPname.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            editRemoveSwimF.textBoxPaddress.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            editRemoveSwimF.textBoxPnum.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            editRemoveSwimF.textBoxPemail.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            editRemoveSwimF.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Swimmer addSwimmer = new Add_Swimmer();
            addSwimmer.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (labelUser.Text == "Admin")
            {
                this.Close();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
            }
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            this.Close();
            Edit_Remove_Swimmer editRemoveSwimF = new Edit_Remove_Swimmer();
            editRemoveSwimF.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Progress_Report_List progRepList = new Progress_Report_List();
            progRepList.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Assessment addAss = new Add_Assessment();
            addAss.Show();
        }
        
    }
}
