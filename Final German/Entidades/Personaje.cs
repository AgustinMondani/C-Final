using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public delegate void AtaqueDeleago(Personaje personaje, int daño);
    public abstract class Personaje : IJugador
    {
        private decimal id;
        private short nivel;
        private string nombre;
        protected int puntosDeDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;
        static Random random;
        private string titulo;

        static short MaximoNivel = 100;
        static short MinimoNivel = 1;

        public event AtaqueDeleago AtaqueLanzado;
        public event AtaqueDeleago AtaqueRecibido;

        public short Nivel { get => nivel; }
        public int PuntosDeVida { get => puntosDeVida; }
        public string Titulo { get => titulo; set => titulo = value; }
        public int PuntosDeDefensa { get => puntosDeDefensa; }
        public string Nombre { get => nombre; }

        static Personaje()
        {
            random = new Random();
        }

        public Personaje(){}
        public Personaje(decimal id, string nombre, short nivel)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentNullException(nombre, "El nombre es null o son espacios en blanco");
            }

            if (nivel < Personaje.MinimoNivel || nivel > Personaje.MaximoNivel)
            {
                throw new BusinessException("El nivel no esta dentro de los parametros");
            }

            this.id = id;
            this.nombre = nombre.Trim(); //elimina espacios al inicio y al final
            this.nivel = nivel;
            this.puntosDeDefensa = 100;
            this.puntosDePoder = 100 * nivel;
            this.puntosDeVida = 500 * nivel;
            AplicarBeneficioDeClase();
        }

        public Personaje(decimal id, string nombre) : this(id, nombre, 1) { }

        protected abstract void AplicarBeneficioDeClase();

        public override int GetHashCode() { return this.id.GetHashCode(); }

        public override bool Equals(object obj) { return (this.GetHashCode()).Equals(obj.GetHashCode()); }

        public static bool operator ==(Personaje obj1, Personaje obj2) { return obj1.Equals(obj2); }

        public static bool operator !=(Personaje obj1, Personaje obj2) { return !(obj1 == obj2);}

        public int Atacar()
        {
            Thread.Sleep(random.Next(1000, 5001));
            int puntosDeAtaque = this.puntosDePoder * random.Next(10, 101) / 100;
            AtaqueLanzado?.Invoke(this, puntosDeAtaque);
            return puntosDeAtaque;
        }

        public void RecibirAtaque(int puntosDeAtaque)
        {
            int puntosDeAtaqueResultantes = puntosDeAtaque - (this.PuntosDeDefensa * random.Next(10, 101) / 100);
            if (puntosDeAtaqueResultantes < 0) { puntosDeAtaqueResultantes = 0; }
            if(this.puntosDeVida < puntosDeAtaqueResultantes)
            {
                this.puntosDeVida = 0;
            }
            else
            {
            this.puntosDeVida -= puntosDeAtaqueResultantes;
            }
            AtaqueRecibido?.Invoke(this, puntosDeAtaqueResultantes);    
        }

        public override string ToString()
        {
            if(this.titulo is not null)
            {
                return $"{this.Nombre}, {this.Titulo}";
            }
            return this.Nombre;
        }
    }
}
