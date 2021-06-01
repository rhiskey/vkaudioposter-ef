using MySql.Data.MySqlClient;
using System;

namespace vkaudioposter_ef
{
    public class CreateInitialSchema
    {
        public static void CreateSchema(bool isFirstLaunch)
        {
            string db = Program.db;
            string qDrop = $"DROP DATABASE `{db}` ;";
            string qCreate = $"CREATE SCHEMA `{db}` ;";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                //Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;
                if (isFirstLaunch)
                {
                    cmd.CommandText = qDrop;
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = qCreate;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            conn.Close();

        }
    }
}
