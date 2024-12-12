using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;

namespace Entidades
{
    public static class BaseDeDatos
    {
        private static string conection = "Server = DESKTOP-NP3CB0L\\MSSQLSERVER777; Database = Laboratorio2; Trusted_Connection = True";
        static SqlConnection sqlConnection;

        static BaseDeDatos() 
        { 
            BaseDeDatos.sqlConnection = new SqlConnection(conection);
        }

        public static bool Agregar(Usuario usuario)
        {
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO usuarios (nombre, apellido, dni, correo, clave) VALUES (@nombre, @apellido, @dni, @correo, @clave)";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("@nombre", "pedro");
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static bool Eliminar(Usuario usuario)
        {
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "DELETE FROM usuarios WHERE dni = @dni";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("dni", "usuario.Dni");
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool Modificar(Usuario usuario)
        {
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "UPDATE usuarios SET nombre = @nombre, apellido = @apellido, correo = @correo, clave = @clave WHERE dni = @dni";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    cmd.Parameters.AddWithValue("dni", "usuario.Dni");
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static List<Usuario> ObtenerTodos()
        {
            List<Usuario> users = new List<Usuario>();
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "SELECT * FROM usuarios";
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nombre, apellido, correo;
                        int dni;
                        nombre = reader.GetString(0);
                        apellido = reader.GetString(1);
                        correo = reader.GetString(3);
                        dni = reader.GetInt32(2);
                        users.Add(new Usuario(nombre, apellido, dni, correo));
                    }
                }
                return users;
            }
            catch
            {
                return users;
            }
        }

    }

    public class Usuario
    {
        public string nombre;
        public string apellido;
        public int dni;
        public string correo;
        public Usuario(string nombre, string apellido, int dni, string correo) 
        { 
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.correo = correo;
        } 
    }
}
