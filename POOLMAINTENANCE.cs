using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Swimming_Pool_Management_System
{
    class POOLMAINTENANCE
    {
        MY_DB db = new MY_DB();

        //Function to add new coach
        public bool insertPoolMain(DateTime dateOfUnav, DateTime dateOfAvail, string typeOfMain)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `pool_maintenance`(`Date of Unavailability`, `Date of Availability`, `Type of Maintenance`) VALUES (@dou, @doa, @tom)", db.getConnection());

            command.Parameters.Add("@dou", MySqlDbType.Date).Value = dateOfUnav;
            command.Parameters.Add("@doa", MySqlDbType.Date).Value = dateOfAvail;
            command.Parameters.Add("@tom", MySqlDbType.VarChar).Value = typeOfMain;


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
        public DataTable getPoolMains(MySqlCommand command)
        {
            command.Connection = db.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
