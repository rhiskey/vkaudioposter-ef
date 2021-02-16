﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_MakeGenres
    {
        public static void CreateMakeGenres()
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
                cmd.CommandText = "DROP VIEW IF EXISTS vw_make_genres_fromDB";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE VIEW vw_make_genres_fromDB AS " +
                    "SELECT * " +
                    "FROM Playlists "+
                    "ORDER BY Playlists.Mood , Playlists.Playlist_Name";

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
                StringBuilder output = new StringBuilder();
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "vw_make_genres_fromDB";
                cmd.CommandType = CommandType.Text;

                //cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                var ordinalPK = reader.GetOrdinal("id");
                var ordinalID = reader.GetOrdinal("Playlist_ID");
                var ordinalName = reader.GetOrdinal("Playlist_Name");
                var ordinalAuthor = reader.GetOrdinal("Playlist_Author");
                while (reader.Read())
                {
                    if (reader.GetValue(ordinalID).ToString() != "\u0000") 
                    {
                        if (reader.IsDBNull(ordinalID) || reader.IsDBNull(ordinalName) || reader.IsDBNull(ordinalAuthor))
                        {                         
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            var val1 = reader.GetValue(ordinalPK); //ID
                            var val2 = reader.GetValue(ordinalName); //Name        
                            var PlAuthor = reader.GetValue(ordinalAuthor); //Author
                            output.AppendLine(reader.GetValue(ordinalID) + " - " + reader.GetValue(1));
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
