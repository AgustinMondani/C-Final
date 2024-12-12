using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Logger
    {
        private string ruta;

        public Logger(string ruta) 
        {
            this.ruta = ruta;
        }

        public void GuardarLog(string texto)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ruta,true))
                {
                    sw.WriteLine(texto);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al guardar el texto");
            }
        }
    }
}
