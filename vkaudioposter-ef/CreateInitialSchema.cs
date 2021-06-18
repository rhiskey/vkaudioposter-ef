using Microsoft.Data.SqlClient;
using System;

namespace vkaudioposter_ef
{
    public class CreateInitialSchema
    {
        public static void CreateSchema(bool isFirstLaunch)
        {
            string db = Program.db;
            string qDrop = $"DROP DATABASE `{db}` ;";
            string qCreate = $"CREATE SCHEMA `{db}` ;";
            SqlConnection conn = new();
            conn.ConnectionString = Program.connStr;
            SqlCommand cmd = new();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                if (isFirstLaunch)
                {
                    cmd.CommandText = qDrop;
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = qCreate;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.StackTrace + " has occurred: " + ex.Message);
            }
            conn.Close();

        }
    }
}
