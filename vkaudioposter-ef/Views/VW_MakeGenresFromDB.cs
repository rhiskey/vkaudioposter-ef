﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_MakeGenresFromDB: IView
    {
        public void CreateView(bool isFirstLaunch)
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
                    cmd.CommandText = "DROP VIEW IF EXISTS vw_make_genres_fromDB";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "CREATE VIEW vw_make_genres_fromDB AS " +
                    "SELECT * " +
                    "FROM Playlists ";

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

                cmd.CommandText = "SELECT * FROM vw_make_genres_fromDB;";
                cmd.CommandType = CommandType.Text;

                //cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                var ordinalPK = reader.GetOrdinal("id");
                var ordinalID = reader.GetOrdinal("Playlist_ID");
                var ordinalName = reader.GetOrdinal("Playlist_Name");
                //var ordinalAuthor = reader.GetOrdinal("Playlist_Author");
                while (reader.Read())
                {
                    if (reader.GetValue(ordinalID).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalID) || reader.IsDBNull(ordinalName))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            var val1 = reader.GetValue(ordinalPK); //ID
                            var val2 = reader.GetValue(ordinalName); //Name        
                            //var PlAuthor = reader.GetValue(ordinalAuthor); //Author
                            var plId = reader.GetValue(ordinalID).ToString();
                            var plName = reader.GetValue(ordinalName).ToString();
                            output.AppendLine($" {plId} - {plName}");
                        }
                    }
                }
                reader.Close();
                Console.WriteLine("vw_make_genres_fromDB");
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
