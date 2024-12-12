using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Hechicero : Personaje
    {
        public Hechicero() : base() { }
        public Hechicero(decimal id, string nombre, short nivel) : base(id, nombre, nivel) { }
        public Hechicero(decimal id, string nombre) : base(id, nombre) { }
        protected override void AplicarBeneficioDeClase()
        {
            this.puntosDePoder += (int)(this.puntosDePoder * 0.10);
        }
    }
}
