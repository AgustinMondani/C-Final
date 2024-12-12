using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IJugador
    {
        short Nivel { get; }
        int PuntosDeVida {  get; }

        int Atacar();
        void RecibirAtaque(int puntosDeAtaque);
    }
}
