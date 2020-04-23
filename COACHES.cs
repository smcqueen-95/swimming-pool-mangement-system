using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class COACHES
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertCoach(string fname, string lname, string gender, DateTime bdate, string age, string address, string phone, string email, string steam)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `coaches`(`First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `Address`, `Phone Number`, `Email`, `Swim Team/s`) VALUES (@fn, @ln, @gdr, @bdt, @age, @adrs, @phn, @email, @smt)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@adrs", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@smt", MySqlDbType.VarChar).Value = steam;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.openConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }

        //Create a function to return a table of swimmers data
        public DataTable getCoaches(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }


        //Creating a function to update swimmer's information
        public bool updateCoach(int id, string fname, string lname, string gender, DateTime bdate, string age, string address, string phone, string email, string steam)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `coaches` SET `First Name`=@fn,`Last Name`=@ln,`Gender`=@gdr,`Birth Date`=@bdt,`Age`=@age,`Address`=@adrs,`Phone Number`=@phn,`Email`=@email,`Swim Team/s`=@smt WHERE `ID`=@id", db.getConnection());

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@adrs", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@smt", MySqlDbType.VarChar).Value = steam;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.openConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        //Creating a function to delete a swimmer
        public bool deleteCoach(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `coaches` WHERE `ID`=@coachID", db.getConnection());

            command.Parameters.Add("@coachID", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.openConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

    }
}
