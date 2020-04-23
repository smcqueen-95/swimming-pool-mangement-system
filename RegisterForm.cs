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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_Form loginForm = new Login_Form();
            loginForm.Show();
        }

        //Checking if the user exists
        public Boolean checkUsername()
        {
            MY_DB db = new MY_DB();
            String username = textBoxUsername.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username`= @usn", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            //Checking if this username already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }
        //check if the textboxes contains their default values
        public Boolean checkTextBoxesValues()
        {
            String fname = textBox1.Text;
            String lname = textBox2.Text;
            String email = textBox3.Text;
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;
            String cPassword = textBox6.Text;
            String userType = comboBox1.Text;
            if (fname.Equals("First Name") || lname.Equals("Last Name") ||
                email.Equals("Email Address") || username.Equals("Username") ||
                password.Equals("Enter Password") || cPassword.Equals("Confirm Password") || userType.Equals("User Type"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void registerbtn_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`First Name`, `Last Name`, `Email`, `Username`, `Password`, `User Type`) VALUES (@fn, @ln, @email, @usn, @pass, @ustype)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@email", MySqlDbType.Text).Value = textBox3.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            command.Parameters.Add("@ustype", MySqlDbType.VarChar).Value = comboBox1.Text;

            //Opening the cnnection
            db.openConnection();
           


            if (!checkTextBoxesValues())
            {
                //Checking if password is equal to confirm password
                if (textBoxPassword.Text.Equals(textBox6.Text))
                {
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists. Try a Different One!", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Confirm Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }

            else
            {
                MessageBox.Show("Please Enter Your Information", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //Closing the connection
            db.closeConnection();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if (fname.Equals("First Name"))
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            String fname = textBox1.Text;
            if (fname.ToLower().Trim().Equals("First Name") || fname.Equals(""))
            {
                textBox1.Text = "First Name";
                textBox1.ForeColor = Color.LightGray;
            }

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            String lname = textBox2.Text;
            if (lname.Equals("Last Name"))
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            String lname = textBox2.Text;
            if (lname.ToLower().Trim().Equals("Last Name") || lname.Equals(""))
            {
                textBox2.Text = "Last Name";
                textBox2.ForeColor = Color.LightGray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            String email = textBox3.Text;
            if (email.Equals("Email Address"))
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            String email = textBox3.Text;
            if (email.ToLower().Trim().Equals("Email Address") || email.Equals(""))
            {
                textBox3.Text = "Email Address";
                textBox3.ForeColor = Color.LightGray;
            }
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.Equals("Username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("Username") || username.Equals(""))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.LightGray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            String cpassword = textBox6.Text;
            if (cpassword.Equals("Confirm Password"))
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            String cpassword = textBox6.Text;
            if (cpassword.ToLower().Trim().Equals("Confirm Password") || cpassword.Equals(""))
            {
                textBox6.Text = "Confirm Password";
                textBox6.ForeColor = Color.LightGray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.Equals("Enter Password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("Enter Password") || password.Equals(""))
            {
                textBoxPassword.Text = "Enter Password";
                textBoxPassword.ForeColor = Color.LightGray;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            String userType = comboBox1.Text;
            if (userType.Equals("User Type"))
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            String userType = comboBox1.Text;
            if (userType.ToLower().Trim().Equals("User Type") || userType.Equals(""))
            {
                comboBox1.Text = "User Type";
                comboBox1.ForeColor = Color.LightGray;
            }
        }
    }
}
