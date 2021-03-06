﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Views
{
    public class VW_StyleCountChart : IView
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
                    cmd.CommandText = "DROP VIEW IF EXISTS vw_style_count_chart";
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "CREATE VIEW vw_style_count_chart AS " +
                    "SELECT Style, PlaylistId, COUNT(0) AS Count " +
                    "FROM PostedTracks " +
                    "ORDER BY PlaylistId " +
                    "GROUP BY PlaylistId";

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

                cmd.CommandText = "SELECT * FROM vw_style_count_chart;";
                cmd.CommandType = CommandType.Text;

                //cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                var ordinalStyle = reader.GetOrdinal("Style");
                var ordinalCount = reader.GetOrdinal("Count");
                var ordinalPlID = reader.GetOrdinal("PlaylistId");

                while (reader.Read())
                {
                    if (reader.GetValue(ordinalStyle).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalPlID) || reader.IsDBNull(ordinalCount))
                        {
                            throw new Exception("returned NULL from Table");
                        }
                        else
                        {
                            var val1 = reader.GetValue(ordinalStyle).ToString();
                            var val2 = reader.GetValue(ordinalCount).ToString();
                            var val3 = reader.GetValue(ordinalPlID).ToString();

                            output.AppendLine($"{val1} - {val2} - {val3}");
                        }
                    }
                }
                reader.Close();
                Console.WriteLine("vw_style_count_chart");
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
