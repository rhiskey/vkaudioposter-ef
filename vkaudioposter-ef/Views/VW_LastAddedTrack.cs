using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_LastAddedTrack:IView
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
                cmd.CommandText = "DROP VIEW IF EXISTS vw_last_added_track";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE VIEW vw_last_added_track AS " +
                    "SELECT * " +
                    "FROM PostedTracks " +
                    "ORDER BY PostedTracks.id DESC "+
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

                cmd.CommandText = "SELECT * FROM vw_last_added_track;";
                cmd.CommandType = CommandType.Text;

                var reader = cmd.ExecuteReader();

                var ordinalPlID = reader.GetOrdinal("PlaylistId");
                var ordinalName = reader.GetOrdinal("Trackname");
                var ordinalDate = reader.GetOrdinal("Date");

                while (reader.Read())
                {
                    if (reader.GetValue(ordinalName).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalName) || reader.IsDBNull(ordinalDate) || reader.IsDBNull(ordinalPlID))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            //var val1 = reader.GetValue(ordinalPK); //ID
                            var val2 = reader.GetValue(ordinalName); //Name        
                            var date = reader.GetValue(ordinalDate).ToString();
                            var plId = reader.GetValue(ordinalPlID).ToString();

                            var plName = reader.GetValue(ordinalName).ToString();
                            output.AppendLine($" {plId} - {date} - {plName}");
                        }
                    }
                }
                reader.Close();
                Console.WriteLine("vw_last_added_track:");
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
