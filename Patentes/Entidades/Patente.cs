using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public enum ETipo { MERCOSUR = 1, VIEJA = 2 };
    public class Patente
    {
        private string _codigoPatente;
        private ETipo _tipoCodigo;

        public string CodigoPatente { get => _codigoPatente; set => _codigoPatente = value; }
        public ETipo TipoCodigo { get => _tipoCodigo; set => _tipoCodigo = value; }

        public Patente() { }

        public Patente(string codigoPatente, ETipo tipoCodigo)
        {
            _codigoPatente = codigoPatente;
            _tipoCodigo = tipoCodigo;
        }

        public override string ToString()
        {
            return _codigoPatente;
        }
    }
}
