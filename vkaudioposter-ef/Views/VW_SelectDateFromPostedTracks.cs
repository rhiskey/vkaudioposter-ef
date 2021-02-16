using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_SelectDateFromPostedTracks : IView
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
                cmd.CommandText = "DROP VIEW IF EXISTS vw_select_date_from_PostedTracks";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE VIEW vw_select_date_from_PostedTracks AS " +
                    "SELECT Date " +
                    "FROM PostedTracks";

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

                cmd.CommandText = "SELECT * FROM vw_select_date_from_PostedTracks;";
                cmd.CommandType = CommandType.Text;

                //cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                var ordinalDate = reader.GetOrdinal("Date");

                while (reader.Read())
                {
                    if (reader.GetValue(ordinalDate).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalDate))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            var val1 = reader.GetValue(ordinalDate).ToString();

                            output.AppendLine($"{val1}");
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
