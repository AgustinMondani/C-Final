using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades.Final
{
    public static class Manejadora
    {
        public static bool DeserializarJSON(string path, out List<Usuario> users)
        {
            try
            {
                string json = File.ReadAllText(path);
                users = JsonSerializer.Deserialize<List<Usuario>>(json);
                return true;
            }
            catch 
            {
                users = new List<Usuario>();
                return false; 
            }
        }
        public static bool EscribirArchivo(List<Usuario> usuarios)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "usuarios.log");
            DateTime dateTime = DateTime.Now;
            string fecha = dateTime.ToString("dd/MMMM/yyyy HH:mm:ss");
            try
            {
                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    sw.WriteLine($"Fecha y Hora: {fecha}");
                    sw.WriteLine($"Apellido: {usuarios[0].Apellido}");
                    sw.WriteLine("Correos:");
                    foreach (Usuario usuario in usuarios)
                    {
                        sw.WriteLine($"{usuario.Correo}");
                    }
                    sw.WriteLine("*************************************************************");
                }
                return true;
            }
            catch
            {
                throw new Exception("problemas");
                return false;
            }
        } 

        public static bool SerializarJSON(List<Usuario> users, string path)
        {
            try
            {
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                return false;
            }
        } 
    }
}
