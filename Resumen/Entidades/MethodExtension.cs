using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extension
    {
        public static double DiferenciaEnSegundos(this DateTime inicio, DateTime fin)
        {
            return (fin - inicio).TotalSeconds;
        }

        public static DateTime fechaInicio = DateTime.Now;
        public static DateTime fechaFin = DateTime.Now;
        static double TiempoTotal { get => fechaInicio.DiferenciaEnSegundos(Extension.fechaFin); } /// llamar al metodo
    }
}
