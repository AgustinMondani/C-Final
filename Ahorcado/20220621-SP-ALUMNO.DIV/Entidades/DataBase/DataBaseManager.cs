using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Exceptions;
using System.Data;

namespace Entidades.DataBase
{
    //8.DataBaseManager será estática:
    //  a.En el constructor de clase inicializar el string connection.
    //  b.GetNuevaPalabra, recibirá el nombre de la tabla sobre la cual realizar el select y
    //  el id de la palabra a obtener. Retornada la palabra leída desde la BD.

    public static class DataBaseManager
    {
        private static SqlConnection sqlConnection;
        private static string stringConnection;

        static DataBaseManager()
        {
            stringConnection = "Server = DESKTOP-NP3CB0L\\MSSQLSERVER777; Database = 20220621SP; Trusted_Connection = True";
            sqlConnection = new SqlConnection(stringConnection);
        }

        public static string GetNuevaPalabra(string tabla, int id)
        {
            try
            {
                using (sqlConnection = new SqlConnection(stringConnection))
                {
                    sqlConnection.Open();
                    string query = $"SELECT * FROM {tabla} WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new DataBaseManagerException("Error al leer de la base de datos");
                    }
                    if (reader.Read())
                    {
                        return reader.GetString(1);
                    }
                    throw new DataBaseManagerException("Palabra no encontrada");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("error");
                throw ex;
            }
            
        }
    }
}
