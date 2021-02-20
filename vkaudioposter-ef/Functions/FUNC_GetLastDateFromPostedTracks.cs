using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace vkaudioposter_ef.Functions
{
    public class FUNC_GetLastDateFromPostedTracks : IFunction
    {
        public void CreateFunction(bool isFirstLaunch)
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
                    cmd.CommandText = "DROP FUNCTION IF EXISTS get_last_date_from_PostedTracks";
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "CREATE FUNCTION get_last_date_from_PostedTracks() RETURNS datetime " +
                                    "READS SQL DATA " +
                                    "DETERMINISTIC " +
                                   "BEGIN " +
                                      "DECLARE lastDate DATETIME; " +
                                        "SELECT Date "+
                                        "FROM PostedTracks " +
                                        "ORDER BY Date DESC LIMIT 1 "+
                                        "INTO lastDate;" +
                                        "RETURN(lastDate); " +
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

        public void TestFunction()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = Program.connStr;
            MySqlCommand cmd = new MySqlCommand();
            string Output = "";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT get_last_date_from_PostedTracks();";
                cmd.CommandType = CommandType.Text;
                MySqlDataReader reader;
                reader = cmd.ExecuteReader();
                var ordinalDate = reader.GetOrdinal("get_last_date_from_PostedTracks()");
                while (reader.Read())
                {

                    if (reader.GetValue(ordinalDate).ToString() != "\u0000")
                    {
                        if (reader.IsDBNull(ordinalDate))
                        {
                            throw new Exception("GetDateFromDB returned NULL from Table");
                        }
                        else
                        {
                            var val1 = reader.GetValue(ordinalDate);
                            Output += reader.GetValue(ordinalDate) + "\n";
                            string datetimeString = val1.ToString();
                          
                        }

                    }
                }
                reader.Close();
                Console.WriteLine("vw_select_date_from_PostedTracks");
                Console.WriteLine(Output);
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

