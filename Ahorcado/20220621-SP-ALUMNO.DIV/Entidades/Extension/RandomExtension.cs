using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    //10.	Extenderá la clase Random la cual retornará un valor de Id aleatorio
    //desde 1 hasta el valor recibido por parámetro.
    public static class RandomExtension
    {
        public static int GetRandomId(this Random value, int hasta)
        {
            return value.Next(1, hasta + 1);
        }
    }
}
