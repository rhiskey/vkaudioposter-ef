using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_SelectDateFromPostedTracks : IView
    {
        public void CreateView(bool isFirstLaunch)
        {
            MySqlConnection conn = new();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new();

            try
            {
                //Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;
                if (isFirstLaunch)
                {
                    cmd.CommandText = "DROP VIEW IF EXISTS vw_select_date_from_PostedTracks";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "CREATE VIEW vw_select_date_from_PostedTracks AS " +
                    "SELECT Date " +
                    "FROM PostedTracks " +
                    "ORDER BY `PostedTracks`.`Date` " +
                    "DESC " +
                    "LIMIT 1";

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            conn.Close();
            //Console.WriteLine("Connection closed.");

        }

        public void TestView()
        {
            MySqlConnection conn = new();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new();
            try
            {
                StringBuilder output = new();
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM vw_select_date_from_PostedTracks ORDER BY Date DESC LIMIT 1;";
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
                Console.WriteLine("vw_select_date_from_PostedTracks:");
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
