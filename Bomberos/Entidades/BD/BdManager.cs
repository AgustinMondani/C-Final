using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.BD
{
    public static class BdManager
    {
        private static SqlConnection connection;
        private static string stringConnection;

        static BdManager()
        {
            BdManager.stringConnection = "Server = . ; Database = bomberos-db; Trusted_Connection = True";
            BdManager.connection = new SqlConnection(stringConnection);
        }

        public static string LeerLog()
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    string query = "SELECT entrada FROM dbo.log";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder stringBuilder = new StringBuilder();

                    if (reader.Read())
                    {
                        stringBuilder.AppendLine(reader.GetString(0));
                    }
                    return stringBuilder.ToString();
                }
            }
            catch
            {
                Console.WriteLine("error");
            }
            return "";
        }

        public static void GaurdarLog(string info)
        {
            try
            {
                using (connection)
                {
                    connection.Open();

                    string query = $"INSERT INTO dbo.log (entrada, alumno) VALUES (@info, 'Agustin Mondani')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@info", info);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("error");
            }
        }
    }
}
