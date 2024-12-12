using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PatenteStringExtension
    {
        public const string patente_mercosur = "^[A-Z]{2}[0-9]{3}[A-Z]{2}$";
        public const string patente_vieja = "^[A-Z]{3}[0-9]{3}$";

        public static Patente ValidarPatente(this string str)
        {
            Patente patenteNueva;
            Regex rgx_v = new Regex(patente_vieja);
            Regex rgx_n = new Regex(patente_mercosur);

            if (rgx_v.IsMatch(str))
            {
                patenteNueva = new Patente(str, ETipo.MERCOSUR);
            }
            else if (rgx_n.IsMatch(str))
            {
                patenteNueva = new Patente(str, ETipo.VIEJA);
            }
            else { throw new PatenteInvalidaException($"{str} no cumple el formato"); }

            return patenteNueva;

        }
    }
}

/* Ayuda

        Regex rgx_v = new Regex(patente_vieja);
        Regex rgx_n = new Regex(patente_mercosur);
        if (rgx_v.IsMatch(str))
        {
            ...
        }
        else if (rgx_n.IsMatch(str))
        {
           ... 
        }
        */
