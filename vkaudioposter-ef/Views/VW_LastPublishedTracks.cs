using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_LastPublishedTracks: IView
    {
        public void CreateView()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                //Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DROP VIEW IF EXISTS vw_last_published_tracks";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE VIEW vw_last_published_tracks AS " +
                    "SELECT Trackname, Style, PlaylistId " +
                    "FROM PostedTracks " +
                    "ORDER BY PostedTracks.id DESC " +
                    "LIMIT 10";

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
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                StringBuilder output = new StringBuilder();
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM vw_last_published_tracks;";
                cmd.CommandType = CommandType.Text;

                var reader = cmd.ExecuteReader();

                var ordinalPlID = reader.GetOrdinal("PlaylistId");
                var ordinalName = reader.GetOrdinal("Trackname");

                while (reader.Read())
                {
                    if (reader.GetValue(ordinalName).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalName) || reader.IsDBNull(ordinalPlID))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            var val2 = reader.GetValue(ordinalName); //Name                              
                            var plId = reader.GetValue(ordinalPlID).ToString();

                            var plName = reader.GetValue(ordinalName).ToString();
                            output.AppendLine($" {plId} -  {plName}");
                        }
                    }
                }
                reader.Close();
                Console.WriteLine("vw_last_published_tracks");
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
