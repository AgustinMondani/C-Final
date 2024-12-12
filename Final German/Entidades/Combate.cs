using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public delegate void RondaDelegate(IJugador jugador1, IJugador jugador2 );
    public delegate void CombateDelegate(IJugador jugador);
    public sealed class Combate
    {
        private IJugador atacado;
        private IJugador atacante;
        static Random random;

        public event RondaDelegate RondaIniciada;
        public event CombateDelegate CombateFinalizado;

        static Combate()
        {
            random = new Random();
        }

        public Combate(IJugador jugador1, IJugador jugador2)
        {
            this.atacante = SeleccionarPrimerAtacante(jugador1, jugador2);

            if (atacante.Equals(jugador1))
            {
                this.atacado = jugador2;
            }
            else
            {
                this.atacado = jugador1;
            }
        }

        private void Combatir()
        {
            IJugador ganador = EvaluarGanador();
            while(ganador is null)
            {
                IniciarRonda();
                ganador = EvaluarGanador();
            }
            CombateFinalizado?.Invoke(ganador);

            ResultadoCombate resutado = new ResultadoCombate(this.atacante.ToString(), this.atacado.ToString(), DateTime.Now);

            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "serializadora.xml");
                
                using (StreamWriter writer = new StreamWriter(ruta))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ResultadoCombate));
                    serializer.Serialize(writer,resutado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar en formato XML", e);
            }
        }

        private IJugador EvaluarGanador()
        {
            if(atacado.PuntosDeVida == 0)
            {
                return atacante;
            }
            else
            {
                IJugador proximoAtacante = atacado;
                atacado = atacante;
                atacante = proximoAtacante;
                return null;
            }

        }

        private void IniciarRonda()
        {
            if(RondaIniciada is not null)
            {
                RondaIniciada.Invoke(atacante, atacado);
                atacado.RecibirAtaque(atacante.Atacar());
            }
        }

        public Task IniciarCombate()
        {

            Task tarea = Task.Run(() =>
            {
                Combatir();
                
            });

            return tarea;
        }

        private IJugador SeleccionarPrimerAtacante(IJugador jugador1, IJugador jugador2)
        {
           
            if(jugador1.Nivel == jugador2.Nivel)
            {
                return this.SeleccionarJugadorAleatoriamente(jugador1, jugador2);    
            }
            else
            {
                if (jugador1.Nivel < jugador2.Nivel)
                {
                    return jugador1;
                }
                else 
                {
                    return jugador2; 
                }
            }
        }

        private IJugador SeleccionarJugadorAleatoriamente(IJugador jugador1, IJugador jugador2)
        {
            ELadosMoneda ladoMoneda = Aleatorio.TirarUnaMoneda();
            if(ladoMoneda == ELadosMoneda.CARA)
            {
                return jugador1;
            }
            else
            {
                return jugador2;
            }
        }
    }
}
