using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_PostedTracksCount : IView
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
                    cmd.CommandText = "DROP VIEW IF EXISTS vw_posted_tracks_count";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "CREATE VIEW vw_posted_tracks_count AS " +
                    "SELECT COUNT(0) AS `COUNT(*)` " +
                    "FROM PostedTracks " +
                    "WHERE (0 <> 1)";

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

                cmd.CommandText = "SELECT * FROM vw_posted_tracks_count;";
                cmd.CommandType = CommandType.Text;

                //cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                var ordinalPK = reader.GetOrdinal("COUNT(*)");

                while (reader.Read())
                {
                    if (reader.GetValue(ordinalPK).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalPK))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            var val1 = reader.GetValue(ordinalPK).ToString();

                            output.AppendLine($" {val1}");
                        }
                    }
                }
                reader.Close();
                Console.WriteLine("vw_posted_tracks_count");
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
