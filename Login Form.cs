using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Swimming_Pool_Management_System
{
    public partial class Login_Form : Form
    {

        public Login_Form()
        {
            Thread t = new Thread(new ThreadStart(startForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void startForm()
        {
            Application.Run(new Splash_Screen());
        }


        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;
            String userType = comboBox1.Text;
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Username`=@usn AND `Password`=@pass AND `User Type`=@ustype", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            command.Parameters.Add("@ustype", MySqlDbType.VarChar).Value = comboBox1.Text;


            //Opening the cnnection
            db.openConnection();

            adapter.SelectCommand = command;

            adapter.Fill(table);


            //Checking if the users exists
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i]["User Type"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("You Are Logged in as " + table.Rows[i][2]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            GLOBAL.username = table.Rows[0]["Username"].ToString();
                            GLOBAL.userType = table.Rows[0]["User Type"].ToString();
                            this.Hide();
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                        }
                        else if (comboBox1.SelectedIndex == 1)
                        {
                            GLOBAL.username = table.Rows[0]["Username"].ToString();
                            GLOBAL.userType = table.Rows[0]["User Type"].ToString();
                            this.Hide();
                            Sailfish_Dashboard sailfishDash = new Sailfish_Dashboard();
                            sailfishDash.Show();
                        }
                        else if (comboBox1.SelectedIndex == 2)
                        {
                            GLOBAL.username = table.Rows[0]["Username"].ToString();
                            GLOBAL.userType = table.Rows[0]["User Type"].ToString();
                            this.Hide();
                            Grenfin_Dashboard grenfinDash = new Grenfin_Dashboard();
                            grenfinDash.Show();
                        }
                        else if (comboBox1.SelectedIndex == 3)
                        {
                            GLOBAL.username = table.Rows[0]["Username"].ToString();
                            GLOBAL.userType = table.Rows[0]["User Type"].ToString();
                            this.Hide();
                            Dolphin_Dashboard dolphinDash = new Dolphin_Dashboard();
                            dolphinDash.Show();
                        }
                        else if (comboBox1.SelectedIndex == 4)
                        {
                            GLOBAL.username = table.Rows[0]["Username"].ToString();
                            GLOBAL.userType = table.Rows[0]["User Type"].ToString();
                            this.Hide();
                            Grenada_Team_Dashboard grenTeamDash = new Grenada_Team_Dashboard();
                            grenTeamDash.Show();
                        }
                    }
                }
            }

            else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Please Enter Your Username to Login!", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (userType.Trim().Equals(""))
                {
                    MessageBox.Show("Please Check The User Type!", "Empty User Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Please Check Your Password!", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Please Check Username OR Password!", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
