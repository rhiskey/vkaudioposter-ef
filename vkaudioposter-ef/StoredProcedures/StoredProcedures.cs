using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using vkaudioposter_ef;

namespace vkaudioposter_ef.StoredProcedures
{
    public class StoredProcedures
    {
        public static void CreateInsertFoundTrack()
        {
            DotNetEnv.Env.TraversePath().Load();

            var server = DotNetEnv.Env.GetString("SERVER");
            var user = DotNetEnv.Env.GetString("USER");
            var pass = DotNetEnv.Env.GetString("PASSWORD");
            var db = DotNetEnv.Env.GetString("DATABASE");

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=" + server + ";user=" + user + ";database=" + db + ";port=3306;password=" + pass + "";
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "DROP PROCEDURE IF EXISTS sp_insert_found_track";
                cmd.ExecuteNonQuery();

                //cmd.CommandText = "DROP TABLE IF EXISTS emp";
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = "CREATE TABLE emp (empno INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY, first_name VARCHAR(20), last_name VARCHAR(20), birthdate DATE)";
                //cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE PROCEDURE sp_insert_found_track(" +
                                   "IN trackname VARCHAR(150), IN style VARCHAR(50), IN dateT DATETIME, IN playlist INT)" +
                                   "BEGIN INSERT INTO PostedTracks(Trackname, Style, Date, PlaylistId) values(trackname, style, dateT, playlist);END";

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            conn.Close();
            Console.WriteLine("Connection closed.");

            //Test
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "sp_insert_found_track";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@trackname", "KVPV - Test Track");
                cmd.Parameters["@trackname"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@style", "");
                cmd.Parameters["@style"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@dateT", "2021-02-16 02:45:00");
                cmd.Parameters["@dateT"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("playlist", 2);
                cmd.Parameters["playlist"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                Console.WriteLine("Track name: " + cmd.Parameters["@trackname"].Value);
                Console.WriteLine("Date: " + cmd.Parameters["@dateT"].Value);
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
