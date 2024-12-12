using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades.Files
{
//4.FileManager será estática.
//  a.En el constructor de clase realizar: 
//      i.En el atributo path se almacenará la referencia al escritorio de la pc.
//      Y se le concatenara un el nombre de la carpeta del parcial: ej {path escritorio}
//          +\\20220621SP\\
//      ii.Llamar al método ValidaExistenciaDeDirectorio.
//  b.ValidaExistenciaDeDirectorio:
//      i.Si no existe el directorio almacenado en path, se creará.
//      ii.En caso de producirse una excepción al momento de la creación, esta deberá ser capturada
//      y relanzada en una nueva excepción denominada FileManagerException,
//      la cual contendrá el mensaje: “Error al crear el directorio”.
//  c.Guardar:
//      i.Será genérico y solo permitirá que los elementos a almacenar sean tipos por referencia.
//      ii.Validar la extensión del nombre del archivo. En caso de que sea:
//          1.JSON, se serializará el elemento recibido.
//          2.TXT, se almacena en texto plano.
//          3.Cualquier otra extensión se lanzará una excepción denominada FileManagerException,
//          la cual contendrá el mensaje “Extensión no permitida”.

    public static class FileManager
    {
        private static string path;

        static FileManager()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "\\20220621SP\\");

            ValidarExistenciaDeDirectorio();
        }

        private static void ValidarExistenciaDeDirectorio()
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch(Exception ex)
            {
                throw new FileManagerException("Error al crear el directorio...");
            }
        }

        public static void Guardar<T>(T elemento, string nombreArchivo) where T : class
        {
            string extension = Path.GetExtension(nombreArchivo).ToLower();
            string archivoPath = Path.Combine(path, nombreArchivo);

            try
            {
                switch (extension)
                {
                    case ".txt":
                        using (StreamWriter streamWriter = new StreamWriter(archivoPath, true))
                        {
                            streamWriter.WriteLine(elemento.ToString());
                        }
                        break;
                    case ".json":
                        string json = JsonSerializer.Serialize(elemento);
                        File.WriteAllText(archivoPath,json);
                        break;
                    default:
                        throw new FileManagerException("Extension no permitida");
                }
            }
            catch (Exception ex) 
            {
                throw new FileManagerException($"Error al guardar/{ex.Message}");
            }
        }
    }
}
