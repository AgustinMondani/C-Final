using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Aleatorio
    {
        public static ELadosMoneda TirarUnaMoneda()
        {
            Random rand = new Random();
            int LadosMoneda = rand.Next(1,3);
            return (ELadosMoneda)LadosMoneda;
        }
    }
}
