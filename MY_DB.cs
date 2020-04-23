using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Swimming_Pool_Management_System
{
    class MY_DB
    {
        //The connection
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=swimming_pool_db");
       

        //Function to open and close the connection
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }

       

        //A function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }
        
    }
}


