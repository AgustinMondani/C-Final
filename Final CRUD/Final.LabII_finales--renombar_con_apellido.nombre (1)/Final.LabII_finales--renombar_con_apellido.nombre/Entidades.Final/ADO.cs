using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Final
{

    public delegate void ApellidoUsuarioExistenteDelegado(object sender, EventArgs e);

    public class ADO
    {
        private static string conexion = "Server = DESKTOP-NP3CB0L\\MSSQLSERVER777; Database = Laboratorio2; Trusted_Connection = True";

        public event ApellidoUsuarioExistenteDelegado ApellidoUsuarioExistente;
        public ADO() { }

        public bool Agregar(Usuario usuario)
        {
            List<Usuario> users = ADO.ObtenerTodos(usuario.Apellido);
            if(users.Count() > 0)
            {
                users.Add(usuario);
                UsuarioApellidoExistenteEventsArgs usersExistentes = new UsuarioApellidoExistenteEventsArgs(users);
                ApellidoUsuarioExistente?.Invoke(this, usersExistentes);
            }
            try
            {
                using(SqlConnection conect = new SqlConnection(conexion))
                {
                    conect.Open();
                    string query = "INSERT INTO usuarios (nombre, apellido, dni, correo, clave) VALUES (@nombre, @apellido, @dni, @correo, @clave)";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    cmd.Parameters.AddWithValue("nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("dni", usuario.Dni);
                    cmd.Parameters.AddWithValue("correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("clave", usuario.Clave);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(Usuario usuario)
        {
            try
            {
                using (SqlConnection conect = new SqlConnection(conexion))
                {
                    conect.Open();
                    string query = "DELETE FROM usuarios WHERE dni = @dni";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    cmd.Parameters.AddWithValue("dni", usuario.Dni);
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

        public bool Modificar(Usuario usuario)
        {
            try
            {
                using (SqlConnection conect = new SqlConnection(conexion))
                {
                    conect.Open();
                    string query = "UPDATE usuarios SET nombre = @nombre, apellido = @apellido, correo = @correo, clave = @clave WHERE dni = @dni";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    cmd.Parameters.AddWithValue("dni", usuario.Dni);
                    cmd.Parameters.AddWithValue("nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("clave", usuario.Clave);
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
            List<Usuario> users = new List<Usuario> ();
            try
            {
                using (SqlConnection conect = new SqlConnection(conexion))
                {
                    conect.Open();
                    string query = "SELECT * FROM usuarios";
                    SqlCommand cmd = new SqlCommand(query, conect);
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

        public static List<Usuario> ObtenerTodos(string apellidoUsuario)
        {
            List<Usuario> users = new List<Usuario>();
            try
            {
                using (SqlConnection conect = new SqlConnection(conexion))
                {
                    conect.Open();
                    string query = "SELECT * FROM usuarios WHERE apellido = @apellidoUsuario";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    cmd.Parameters.AddWithValue("apellidoUsuario", apellidoUsuario);
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
}
