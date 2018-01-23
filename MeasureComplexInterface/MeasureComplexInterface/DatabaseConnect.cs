using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace MeasureComplexInterface
{
    public class DatabaseConnect
    {
        DataSet ds = new DataSet();
        NpgsqlConnection npgsqlConnection;
        public DatabaseConnect()
        {
            string connectionString = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "127.0.0.1", "5432", "postgres",
                    "postgres", "com_slash_usb");
            npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();
        }

        public List<string> SelectQuery(string sqlquery)
        {
            List<string> result = new List<string>();        
            result.Clear();
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlquery, npgsqlConnection))            
            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlquery, npgsqlConnection))                
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                    result.Add(reader["date_time"].ToString());
            return result;
        }

        public List<string> UpdateRotorInfo(string[] param)
        {
            List<string> result = new List<string>();
            result.Clear();
            var query2 = "select id from rotor order by id desc limit 1";
            var query = string.Format(
                "insert into rotor(\"type\",\"vane_width\",\"vane_height\",\"turbine_diameter\", \"arm\") values('{0}','{1}','{2}','{3}','{4}')",
                param[0], param[1], param[2], param[3], param[4]);

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, npgsqlConnection))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                    result.Add(reader[0].ToString());

            using (NpgsqlCommand cmd = new NpgsqlCommand(query2, npgsqlConnection))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                    result.Add(reader[0].ToString());
            return result;
        }
    }
}
