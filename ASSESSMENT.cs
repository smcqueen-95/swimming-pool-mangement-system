using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class ASSESSMENT
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertAssessment(string fname, string lname, string age, DateTime date, string swimT, string swimG, string grade)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `assessment`(`First Name`, `Last Name`, `Age`, `Date`, `Swim Team/s`, `Swim Group`, `Grade`) VALUES (@fn, @ln, @age, @date, @swimt, @swimg, @grade)", db.getConnection());

            //@fn, @ln, @age, @watadj, @fainwat, @subhead, @blowb, @flbck, @flstmch
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@swimt", MySqlDbType.VarChar).Value = swimT;
            command.Parameters.Add("@swimg", MySqlDbType.VarChar).Value = swimG;
            command.Parameters.Add("@grade", MySqlDbType.VarChar).Value = grade;

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
        public DataTable getAssessments(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

    }
}

