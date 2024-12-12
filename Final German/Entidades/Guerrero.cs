using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Guerrero : Personaje
    {
        public Guerrero() : base() { }
        public Guerrero(decimal id, string nombre, short nivel) : base(id,nombre,nivel) { }
        public Guerrero(decimal id, string nombre) : base(id, nombre) { }
        protected override void AplicarBeneficioDeClase()
        {
            this.puntosDeDefensa += (int)(this.puntosDeDefensa * 0.10);
        }
    }
}
