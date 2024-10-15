using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace @interface
{
    class dbHandler : idbHandler
    {
        MySqlConnection connection;
        string table = "users";
        public dbHandler()
        {
            string user = "root";
            string password = "";
            string server = "localhost";
            string database = "users";
            string conString = $"user = {user}; password = {password}; server = {server}; database = {database}";
            connection = new MySqlConnection(conString);
        }
        public void delete(user one)
        {
            try
            {
                connection.Open();
                string query = $"delete from {table} where id = {one.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void deleteAll()
        {
            try
            {
                connection.Open();
                string query = $"delete from {table}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insert(user one)
        {
            try
            {
                connection.Open();
                string query = $"insert into {table} (username, password) values ('{one.username}', '{one.password}')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void read()
        {
            try
            {
                connection.Open();
                string query = $"select * from {table}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    user one = new user();
                    one.username = read.GetString(read.GetOrdinal("username"));
                    one.password = read.GetString(read.GetOrdinal("password"));
                    one.points = read.GetInt32(read.GetOrdinal("points"));
                    one.id = read.GetInt32(read.GetOrdinal("id"));
                    user.users.Add(one);
                }
                read.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void update(user one)
        {
            try
            {
                connection.Open();
                string query = $"update {table} set points = {one.points} where id = {one.id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
