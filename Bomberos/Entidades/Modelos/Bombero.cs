using Entidades.BD;
using Entidades.Interfaces;
using System;
using System.Xml.Serialization;

namespace Entidades.Modelos
{
    public delegate void FinDeSalida(int bomberoIndex);
    public class Bombero : IArchivos<Bombero>, IArchivos<string>
    {
        private string nombre;
        public List<Salida> salidas;
        private static string archivoPath;
        private static Random rand;
        public event FinDeSalida MarcarFin;

        static Bombero()
        {
            archivoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Bombero.xml");
            rand = new Random();
        }
        public Bombero(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Bombero()
        {
            salidas = new List<Salida>();
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public void Guardar(Bombero info)
        {
            using (StreamWriter streamWriter = new StreamWriter(archivoPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bombero));
                xmlSerializer.Serialize(streamWriter, this);
            }
        }

        void IArchivos<string>.Guardar(string info)
        {
            BdManager.GaurdarLog(info);
        }

        public Bombero Leer()
        {
            using (StreamReader streamReader = new StreamReader(archivoPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Bombero));
                Bombero bombero = (Bombero)xmlSerializer.Deserialize(streamReader);
                return bombero;
            }
        }

        string IArchivos<string>.Leer()
        {
            return BdManager.LeerLog();
        }

        public void AtenderSalida(int bomberoIndex)
        {

            Salida salida = new Salida();
            salidas.Add(salida);

            Thread.Sleep(rand.Next(2000, 4001));
            salida.FinalizarSalida();
            
            string log = $"Inicio: {salida.FechaInicio.ToLongTimeString()}, Fin: {salida.FechaFin.ToLongTimeString}, Duracion: {salida.TiempoTotal} segundos";

            MarcarFin(bomberoIndex);

        }
    }


}
