using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAOSisVen.Implementation
{
    public class BaseImpl
    {
        string connectionstring = @"server=localhost;database=bdincos2023;Uid=root;pwd=12qwaszx;Port=3306";
        public string query = "";

        public MySqlCommand CreateBasicCommand () {   
            MySqlConnection connection = new MySqlConnection(connectionstring);
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            return command;
        }

        public MySqlCommand CreateBasicCommand(string query)
        {      
            MySqlConnection connection = new MySqlConnection(connectionstring);
            MySqlCommand command = new MySqlCommand(query,connection);
           
            return command;
        }
        //INSERTS UPDATES Y DELETES
        public int ExecuteBasicCommand(MySqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        //crearemos otro metodo generico que nos ejecute un SELECT
        public DataTable ExecuteDataTableCommand(MySqlCommand command)
        {
            DataTable datatable = new DataTable();
            try
            {
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(datatable);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return datatable; 
        }
    }
}
