using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Models
{
    //15.Ahorcado, será genérica, solo podrá recibir tipos que implementen
    //  la interfaz Ilector y posean un constructor publico sin parámetros:
    //  a.En su constructor publico sin parámetros realizar:
    //      i.Instanciar el atributo entidad.
    //      ii.Inicializar:
    //          1.	estaAdivinada en false.
    //          2.	cantidadIntentosPorPalabra y cantidadAciertos en 0 (cero).
    //          3.	palabraSecreta en empty.
    //16.La propiedad Activar:
    //  a.El GET retornara True, si la tares no es nula y estado de la tarea es Running o WaitingToRun o WaitingForActivation.
    //  b.En el SET, si el valor recibido es TRUE y la tarea es nula o su estado no es Running o no es WaitingToRun o no es WaitingForActivation, se instanciará un nuevo CancelationTokenSource y se llamará a IniciarJuego. De lo contrario se llamará al método Cancel de cancellation.
    //17.El método IniciarJuego será privado y:
    //  a.Ejecutara en un hilo secundario la acción de que:
    //      i.Mientras no se requiera cancelación de la tarea invocara al mensaje
    //      NotificarNuevaPalabra y luego NotificarSegundosRestantes.Para este último enviar 30 segundos.
    //18.El método NotificarNuevaPalabra, verificara si el evento OnPalabra posee suscriptores
    //  y en caso exitoso realizara:
    //  a.Cambiar el estado del atributo estaAdivinada a False.
    //  b.Guardara en palabraSecreta el valor obtenido desde la entidad.
    //  c.cantidadDeIntentosPorPalabra será igual al doble de la longitud de la palabra secreta.
    //  d.Notificara la palabra secreta.
    //19.El método NotificarSegundosRestantes si posee un suscriptor notificara los segundos
    //restantes mientras que (Utilizar Thread.Sleep para dormir el hilo 1 segundos antes de ir decrementando):
    //  a.segundosRestantes sea mayor o igual a cero.
    //  b.El hilo secundario no requiera cancelación.
    //  c.La palabra no haya sido adivinada.
    //  d.La cantidad de intentos sea mayor que 0 (cero).
    //20.El método AsertarPalabra comparara la palabra secreta con la recibida por parámetro (usar ToLower para comparar).  Si son iguales cambiara el estado de estaAdivinada a True e incrementara el valor de cantidadDeAciertos en 1 (uno). De lo contrario restara cantidadDeIntentosPorPalabra.


    public delegate void DelegadoNuevaPalabra(string palabra);
    public delegate void DelegadoTemporizador(int segundos);

    public class Ahorcado<T> where T : ILector, new()
    {
        private CancellationTokenSource cancellation;
        private int cantidadDeAciertos;
        private int cantidaDeIntentosPorPalabra;
        private T entidad;
        private bool estaAdivinada;
        private string palabraSecreta;
        private Task tarea;

        public event DelegadoNuevaPalabra OnPalabra;
        public event DelegadoTemporizador OnTemporizador;
        public Ahorcado()
        {
            this.entidad = new T();
            this.estaAdivinada = false;
            this.cantidaDeIntentosPorPalabra = 0;
            this.cantidadDeAciertos = 0;
            this.palabraSecreta = string.Empty;
        }

        public bool Activar
        {
            get
            {
                return this.tarea is not null && (this.tarea.Status == TaskStatus.Running ||
                    this.tarea.Status == TaskStatus.WaitingToRun ||
                    this.tarea.Status == TaskStatus.WaitingForActivation);
            }
            set 
            {
                if (value == true && !this.Activar)
                {
                    this.cancellation = new CancellationTokenSource();
                    this.IniciarJuego();
                }
                else
                {
                    this.cancellation.Cancel();
                }
            }
        }
        public int CantidadDeAciertos { get => cantidadDeAciertos; }
        public int CantidaDeIntentosPorPalabra { get => cantidaDeIntentosPorPalabra; }

        private void IniciarJuego()
        {
            tarea = Task.Run(() =>
            {
                if (!cancellation.IsCancellationRequested)
                {
                    this.NotificarNuevaPalabra();
                    this.NotificarSegundosRestantes(30);
                }
            },cancellation.Token);
        }

        private void NotificarNuevaPalabra()
        {
            if(OnPalabra is not null)
            {
                this.estaAdivinada = false;
                this.palabraSecreta = this.entidad.ObtenerNuevaPalabra();
                this.cantidaDeIntentosPorPalabra = this.palabraSecreta.Length * 2;
                OnPalabra(this.palabraSecreta);
            }
        }

        private void NotificarSegundosRestantes(int segundosRestantes)
        {
            if(OnTemporizador is not null)
            {
                int segundos = segundosRestantes;
                while(segundos >= 0 && !cancellation.IsCancellationRequested && !this.estaAdivinada && this.CantidaDeIntentosPorPalabra > 0)
                {
                    Thread.Sleep(1000);
                    segundos--;
                    OnTemporizador(segundos);
                }
            }
            cancellation.Cancel();
        }

        public bool AsertPalabra(string palabra)
        {
            if(this.palabraSecreta == palabra.ToLower())
            {
                this.estaAdivinada = true;
                this.cantidadDeAciertos++;
                return true;
            }
            else
            {
                this.cantidaDeIntentosPorPalabra--;
                return false;
            }
        }
        #region Codigo extra
        // Sobrecarga del operador ==
        public static bool operator ==(Ahorcado<T> p1, Ahorcado<T> p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.estaAdivinada == p2.estaAdivinada && p1.estaAdivinada == p2.estaAdivinada;
        }

        // Sobrecarga del operador !=
        public static bool operator !=(Ahorcado<T> p1, Ahorcado<T> p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Personaje p = (Personaje)obj;
            return Id == p.Id;
        }

        // Sobrescribir GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }


        public string EliminarEspaciosEnBlanco(string palabra)
        {
            return palabra.Trim();
        }

        public Task IniciarCombate()
        {
            return Task.Run(() => Combatir());
        }
        #endregion
    }
}
