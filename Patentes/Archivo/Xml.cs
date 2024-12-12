using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    public class Xml : IArchivo
    {
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                string archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
                using (StreamWriter streamWriter = new StreamWriter(archivoPath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Patente>));
                    xmlSerializer.Serialize(streamWriter,datos);
                }
                return true;
            }
            catch
            {
                throw new Exception("error al serializar");
            }
        }
        
        public List<Patente> Leer()
        {

            List<Patente> patentes = new List<Patente>();
            try
            {
                string archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
                using (StreamReader streamReader = new StreamReader(archivoPath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Patente>));
                    patentes = (List<Patente>)xmlSerializer.Deserialize(streamReader);
                }
            }
            catch
            {
                throw new Exception("error al leer");
            }
            return patentes;
        }
    }
}
