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
    public partial class Grenada_Team : Form
    {
        public Grenada_Team()
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
                Grenada_Swim_Team grenSwim = new Grenada_Swim_Team();
                grenSwim.Show();
            }
            else if (labelUser.Text == "Grenada Team Leader")
            {
                this.Hide();
                Grenada_Swim_Team grenSwim = new Grenada_Swim_Team();
                grenSwim.Show();
            }
        }

        SWIMMER swimmer = new SWIMMER();

        private void Grenada_Team_Load(object sender, EventArgs e)
        {
            labelUser.Text = GLOBAL.userType;

            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers` WHERE `Swim Team/s`='Sailfish and Grenada' OR 'Grenfin and Grenada' OR 'Dolphin and Grenada'");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = swimmer.getSwimmers(command);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Remove_Swimmer editRemoveSwimF = new Edit_Remove_Swimmer();
            editRemoveSwimF.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //populating the datagridview with swimmer's data
            MySqlCommand command = new MySqlCommand("SELECT * FROM `swimmers` WHERE `Swim Team/s`='Sailfish and Grenada' OR 'Grenfin and Grenada' OR 'Dolphin and Grenada'");
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
    }
}
