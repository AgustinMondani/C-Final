using Entidades;

namespace ConsolaPrograma
{
    public class Progrma
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "logger.txt"));
            try
            {
                Personaje personaje1 = PersonajeDAO.ObtenerPersonajePorId(1);
                Personaje personaje2 = PersonajeDAO.ObtenerPersonajePorId(2);
                Combate combate = new Combate(personaje1, personaje2);
                Console.WriteLine("¡FIGHT!");


                personaje1.AtaqueLanzado += MostrarAtaqueLanzado;
                personaje2.AtaqueLanzado += MostrarAtaqueLanzado;

                personaje1.AtaqueRecibido += MostrarAtaqueRecibido;
                personaje2.AtaqueRecibido += MostrarAtaqueRecibido;

                combate.RondaIniciada += IniciarRonda;
                combate.CombateFinalizado += FinalizarCombate;

                combate.IniciarCombate().Wait();
                
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                string mensaje = $"{ex.Message} \n{ex.StackTrace}";
                Console.WriteLine(mensaje);
                logger.GuardarLog(mensaje);
            }
            
        }
        static void IniciarRonda(IJugador atacante, IJugador atacado)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"¡{atacante} ataca a {atacado}!");
        }
        static void FinalizarCombate(IJugador ganador)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Combate finalizado. El ganador es {ganador}.");
        }
        static void MostrarAtaqueLanzado(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{personaje} lanzó un ataque de {puntosDeAtaque} puntos.");
        }
        static void MostrarAtaqueRecibido(Personaje personaje, int puntosDeAtaque)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{personaje} recibió un ataque por {puntosDeAtaque} puntos.Le quedan {personaje.PuntosDeVida} puntos de vida.");
        }

    }

}
