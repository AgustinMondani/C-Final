using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PersonajeDAO
    {
        public static Personaje ObtenerPersonajePorId(decimal id)
        {
            string conection = "Server = DESKTOP-NP3CB0L\\MSSQLSERVER777; Database = COMBATE_DB; Trusted_Connection = True";
            Personaje? personaje = null;

            using (SqlConnection sqlConnection = new SqlConnection(conection))
            {
                sqlConnection.Open();
                string query = "SELECT * FROM PERSONAJES WHERE id = @id ";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.AddWithValue("id", id);
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                if(reader.Read())
                {
                    decimal personajeId = reader.GetInt32(0);
                    string personajeNombre = reader.GetString(1);
                    short personajeNivel = reader.GetInt16(2);

                    if(reader.GetInt16(3) == 1)
                    {
                        personaje = new Guerrero(personajeId, personajeNombre, personajeNivel);
                    }
                    else if(reader.GetInt16(3) == 2)
                    {
                        personaje = new Hechicero(personajeId, personajeNombre, personajeNivel);
                    }

                    try
                    {
                        string personajeTitulo = reader.GetString(4);
                        personaje.Titulo = personajeTitulo;
                    }
                    catch { }
                }
                return personaje;
            }
        }
    }
}
