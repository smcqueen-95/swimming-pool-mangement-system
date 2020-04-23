using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class COACHATTENDANCE
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertCoachAtten(string fname, string lname, DateTime date, string swimT, string arrTime, string sessTaught)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `coaches_atten`(`First Name`, `Last Name`, `Date`, `Swim Team/s`, `Arrival Time`, `Session/s Taught`) VALUES (@fn, @ln, @date, @swmt, @arrt, @sesst)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@swmt", MySqlDbType.VarChar).Value = swimT;
            command.Parameters.Add("@arrt", MySqlDbType.VarChar).Value = arrTime;
            command.Parameters.Add("@sesst", MySqlDbType.VarChar).Value = sessTaught;


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
        public DataTable getCoachesAtten(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
