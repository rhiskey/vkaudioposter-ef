using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.StoredProcedures
{
    public class SP_CheckTrackInUnfound : IStoredProcedure
    {
        public void CreateProcedure(bool isFirstLaunch)
        {
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
                    cmd.CommandText = "DROP PROCEDURE IF EXISTS sp_check_track_in_unfound";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "CREATE PROCEDURE sp_check_track_in_unfound(" +
                                    "IN in_trackname VARCHAR(200), IN in_playlist INT)" +
                                   //"IN in_trackname VARCHAR(200), IN in_style VARCHAR(60), IN in_playlist INT)" +
                                   "BEGIN " +
                                   "SELECT 1 FROM UnfoundTracks " +
                                   "WHERE Trackname = in_trackname " +
                                   "AND PlaylistId = in_playlist; " +
                                   "END";

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            conn.Close();
            //Console.WriteLine("Connection closed.");
        }

        public void TestProcedure(string trackname, string style, DateTime? date, int? playlistID)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();
            //Test
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "sp_check_track_in_unfound";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@in_trackname", trackname);
                cmd.Parameters["@in_trackname"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@in_playlist", playlistID);
                cmd.Parameters["@in_playlist"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                Console.WriteLine("sp_check_track_in_unfound Track name: " + cmd.Parameters["@in_trackname"].Value);
                Console.WriteLine("Style: " + cmd.Parameters["@in_playlist"].Value);
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
