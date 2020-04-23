using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class SWIMMER
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertSwimmer(string fname, string lname, string gender, DateTime bdate, string age, string school, string medical, string swimt, string swimg, string pname, string paddress, string pnum, string pemail)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `swimmers`(`First Name`, `Last Name`, `Gender`, `Birth Date`, `Age`, `School`, `Medical`, `Swim Team/s`, `Swim Group`, `Parent/s Name`, `Parent/s Address`, `Parent/s Number`, `Parent Email`) VALUES (@fn, @ln, @gdr, @bdt, @age, @sch, @med, @swmt, @swmg, @pname, @paddrs, @pnum, @pemail)", db.getConnection());

            //@fn, @ln, @gdr, @bdt, @age, @sch, @med, @swmt, @swml, @pname, @paddrs, @pnum, @pemail, @stdp
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@sch", MySqlDbType.VarChar).Value = school;
            command.Parameters.Add("@med", MySqlDbType.VarChar).Value = medical;
            command.Parameters.Add("@swmt", MySqlDbType.VarChar).Value = swimt;
            command.Parameters.Add("@swmg", MySqlDbType.VarChar).Value = swimg;
            command.Parameters.Add("@pname", MySqlDbType.VarChar).Value = pname;
            command.Parameters.Add("@paddrs", MySqlDbType.VarChar).Value = paddress;
            command.Parameters.Add("@pnum", MySqlDbType.VarChar).Value = pnum;
            command.Parameters.Add("@pemail", MySqlDbType.VarChar).Value = pemail;

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
        public DataTable getSwimmers(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        //Creating a function to update swimmer's information
        public bool updateSwimmer(int id, string fname, string lname, string gender, DateTime bdate, string age, string school, string medical, string swimt, string swimg, string pname, string paddress, string pnum, string pemail)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `swimmers` SET `First Name`=@fn,`Last Name`=@ln,`Gender`=@gdr,`Birth Date`=@bdt,`Age`=@age,`School`=@sch,`Medical`=@med,`Swim Team/s`=@swmt,`Swim Group`=@swmg,`Parent/s Name`=@pname,`Parent/s Address`=@paddrs,`Parent/s Number`=@pnum,`Parent Email`=@pemail WHERE `ID` =@id", db.getConnection());

            //@fn, @ln, @gdr, @bdt, @age, @sch, @med, @swmt, @swml, @pname, @paddrs, @pnum, @pemai, @stdp
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@sch", MySqlDbType.VarChar).Value = school;
            command.Parameters.Add("@med", MySqlDbType.VarChar).Value = medical;
            command.Parameters.Add("@swmt", MySqlDbType.VarChar).Value = swimt;
            command.Parameters.Add("@swmg", MySqlDbType.VarChar).Value = swimg;
            command.Parameters.Add("@pname", MySqlDbType.VarChar).Value = pname;
            command.Parameters.Add("@paddrs", MySqlDbType.VarChar).Value = paddress;
            command.Parameters.Add("@pnum", MySqlDbType.VarChar).Value = pnum;
            command.Parameters.Add("@pemail", MySqlDbType.VarChar).Value = pemail;

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
        public bool deleteSwimmer(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `swimmers` WHERE `ID`=@swimID", db.getConnection());

            command.Parameters.Add("@swimID", MySqlDbType.Int32).Value = id;

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
