using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace Archivo
{
    public class Texto : IArchivo
    {
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                string archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.txt");
                using (StreamWriter streamWriter = new StreamWriter(archivoPath, false)) // false para sobreescribir el archivo
                {
                    foreach (Patente patente in datos)
                    {
                        streamWriter.WriteLine($"{patente.CodigoPatente},{patente.TipoCodigo}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                
                // Loguear el error si es necesario
                Console.WriteLine($"Error al guardar patentes: {ex.Message}");
                return false;
            }
        }

        public List<Patente> Leer()
        {
            List<Patente> patentes = new List<Patente>();
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
                            patentes.Add((codigo.ValidarPatente()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Loguear el error si es necesario
                Console.WriteLine($"Error al leer patentes: {ex.Message}");
            }
            return patentes;
        }
    }
}
