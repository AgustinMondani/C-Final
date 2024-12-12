using System.Data.SqlClient;

namespace Entidades.Final
{
    public class Login
    {
        protected string email;
        private string pass;

        public string Email {  get => email; }
        protected string Pass { get => pass; }

        public Login(string correo, string clave)
        {
            this.email = correo;
            this.pass = clave;
        }

        public bool Loguear()
        {
            string conexion = "Server = DESKTOP-NP3CB0L\\MSSQLSERVER777; Database = Laboratorio2; Trusted_Connection = True";
            try
            {
                using (SqlConnection conect = new SqlConnection(conexion))
                {
                    conect.Open();
                    string query = "SELECT * FROM usuarios WHERE correo = @email AND clave = @pass";
                    SqlCommand cmd = new SqlCommand(query, conect);
                    cmd.Parameters.AddWithValue("email", this.email);
                    cmd.Parameters.AddWithValue("pass", this.pass);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
