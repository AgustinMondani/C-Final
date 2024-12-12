using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Metodos_de_Extension
{
    public static class Extension
    {
        public static double DiferenciaEnSegundos(this DateTime inicio, DateTime fin)
        {
            return (fin - inicio).TotalSeconds;
        }
    }
}
