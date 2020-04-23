using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class STUDENTPROG
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertStudentProgress(string fname, string lname, string age, string swimT, string swimG, DateTime date, string swimRace, string timeRace, string comment)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student_progress`(`First Name`, `Last Name`, `Age`, `Swim Team/s`, `Swim Group`, `Date`, `Swim Race`, `Time in Race`, `Comment`) VALUES (@fn, @ln, @age, @swmt, @swmG, @date, @swmr, @tmer, @comm)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@swmt", MySqlDbType.VarChar).Value = swimT;
            command.Parameters.Add("@swmg", MySqlDbType.VarChar).Value = swimG;
            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@swmr", MySqlDbType.VarChar).Value = swimRace;
            command.Parameters.Add("@tmer", MySqlDbType.VarChar).Value = timeRace;
            command.Parameters.Add("@comm", MySqlDbType.VarChar).Value = comment;


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
        public DataTable getStudentsProgress(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}


