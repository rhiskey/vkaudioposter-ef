using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_LoadPhotostocksFromDB:IView
    {
        public void CreateView()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DROP VIEW IF EXISTS vw_load_photostocks_fromDB";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE VIEW vw_load_photostocks_fromDB AS " +
                    "SELECT URL " +
                    "FROM console_Photostocks ";

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            conn.Close();
            Console.WriteLine("Connection closed.");

        }

        public void TestView()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                StringBuilder output = new StringBuilder();
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM vw_load_photostocks_fromDB;";
                cmd.CommandType = CommandType.Text;

                var reader = cmd.ExecuteReader();

                var ordinalURL = reader.GetOrdinal("URL");

                while (reader.Read())
                {
                    if (reader.GetValue(ordinalURL).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalURL))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {                          
                            var plId = reader.GetValue(ordinalURL).ToString();
                            output.AppendLine($" {plId}");
                        }
                    }
                }
                reader.Close();
                Console.WriteLine(output.ToString());
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
    }
}
