using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class STUDENTFINANCE
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertStudentFinance(string fname, string lname, string swimT, string swimG, string term1, string term2, string term3)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student_finance`(`First Name`, `Last Name`, `Swim Team/s`, `Swim Group`, `Term 1`, `Term 2`, `Term 3`) VALUES (@fn, @ln, @swmt, @swmg, @term1, @term2, @term3)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@swmt", MySqlDbType.VarChar).Value = swimT;
            command.Parameters.Add("@swmg", MySqlDbType.VarChar).Value = swimG;
            command.Parameters.Add("@term1", MySqlDbType.VarChar).Value = term1;
            command.Parameters.Add("@term2", MySqlDbType.VarChar).Value = term2;
            command.Parameters.Add("@term3", MySqlDbType.VarChar).Value = term3;


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
        public DataTable getStudentsFinance(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        //Function to add new coach
        public bool updateStudentFinance(int id, string fname, string lname, string swimT, string swimG, string term1, string term2, string term3)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student_finance` SET `First Name`=@fn,`Last Name`=@ln,`Swim Team/s`=@swmt,`Swim Group`=@swmg,`Term 1`=@term1,`Term 2`=@term2,`Term 3`=@term3 WHERE `ID`=@id", db.getConnection());

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@swmt", MySqlDbType.VarChar).Value = swimT;
            command.Parameters.Add("@swmg", MySqlDbType.VarChar).Value = swimG;
            command.Parameters.Add("@term1", MySqlDbType.VarChar).Value = term1;
            command.Parameters.Add("@term2", MySqlDbType.VarChar).Value = term2;
            command.Parameters.Add("@term3", MySqlDbType.VarChar).Value = term3;


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
