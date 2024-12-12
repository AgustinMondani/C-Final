using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public static class Archivos
    {
        public static bool DeserializarJSON(string path, out List<Usuario> users) // Deserealizar una lista de objetos
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
        public static bool EscribirArchivo(List<Usuario> usuarios) //Escribir archivo txt
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "usuarios.log");
            DateTime dateTime = DateTime.Now;
            string fecha = dateTime.ToString("dd/MMMM/yyyy HH:mm:ss");
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"Fecha y Hora: {fecha}");
                    sw.WriteLine($"Apellido: {usuarios[0].apellido}");
                    sw.WriteLine("Correos:");
                    foreach (Usuario usuario in usuarios)
                    {
                        sw.WriteLine($"{usuario.correo}");
                    }
                    sw.WriteLine("*************************************************************");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SerializarJSON(List<Usuario> users, string path) //Serializar a JSON una lista de objetos
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
        public static bool Guardar(List<Usuario> datos)  //Serializar en XML
        {
            try
            {
                string archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
                using (StreamWriter streamWriter = new StreamWriter(archivoPath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Usuario>));
                    xmlSerializer.Serialize(streamWriter, datos);
                }
                return true;
            }
            catch
            {
                throw new Exception("error al serializar");
            }
        }
        public static List<Usuario> LeerXML() //Deserializar XML
        {

            List<Usuario> patentes = new List<Usuario>();
            try
            {
                string archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
                using (StreamReader streamReader = new StreamReader(archivoPath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Usuario>));
                    patentes = (List<Usuario>)xmlSerializer.Deserialize(streamReader);
                }
            }
            catch
            {
                throw new Exception("error al leer");
            }
            return patentes;
        }
        public static List<Usuario> LeerTexto() //Leer texto
        {
            List<Usuario> patentes = new List<Usuario>();
            try
            {
                string archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.txt");
                using (StreamReader streamReader = new StreamReader(archivoPath))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] partes = line.Split(',');
                        if (partes.Length == 2)
                        {
                            string codigo = partes[0];
                            patentes.Add((new Usuario("pedroo", "pica", 2323, "dwaa")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer patentes: {ex.Message}");
               
            }
            return patentes;
        }
    }
}
