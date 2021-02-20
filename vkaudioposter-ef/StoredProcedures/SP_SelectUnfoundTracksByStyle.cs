using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.StoredProcedures
{
    class SP_SelectUnfoundTracksByStyle : IStoredProcedure
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
                    cmd.CommandText = "DROP PROCEDURE IF EXISTS sp_select_unfoundtracks_by_style";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "CREATE PROCEDURE sp_select_unfoundtracks_by_style(" +
                                   "IN in_style VARCHAR(60), IN in_playlist INT)" +
                                   "BEGIN " +
                                   "SELECT * FROM UnfoundTracks " +
                                   "WHERE Style = in_style " +
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

                cmd.CommandText = "sp_select_unfoundtracks_by_style";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@in_style", style);
                cmd.Parameters["@in_style"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@in_playlist", playlistID);
                cmd.Parameters["@in_playlist"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                Console.WriteLine("sp_select_unfoundtracks_by_style Style: " + cmd.Parameters["@in_style"].Value);
                Console.WriteLine("Playlist: " + cmd.Parameters["@in_playlist"].Value);
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
