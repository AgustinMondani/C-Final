using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Archivo;
using System.Threading;
using Patentes;

namespace Formulario
{
    /// <summary>
    /// Formulario principal para la gestión de patentes.
    /// </summary>
    public partial class FrmPricipal : Form
    {
        List<Patente> patentes;
        List<Thread> threads;
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmPricipal"/>.
        /// </summary>
        public FrmPricipal()
        {
            InitializeComponent();
            patentes = new List<Patente>();
            threads = new List<Thread>();
        }

        /// <summary>
        /// Manejador del evento Load del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_Load(object sender, EventArgs e)
        {
            VistaPatente vistaPatente = new VistaPatente();
            vistaPatente.finExposicion += ProximaPatente;
            this.Controls.Add(vistaPatente);
        }

        /// <summary>
        /// Manejador del evento FormClosing del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarSimulacion();
        }

        /// <summary>
        /// Manejador del evento Click del botón para agregar más patentes.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                List<Patente> listPatente = new List<Patente>
                {
                    new Patente("CP709WA", ETipo.MERCOSUR),
                    new Patente("DIB009", ETipo.VIEJA),
                    new Patente("FD010GC", ETipo.MERCOSUR)
                };

                // Implementar acá el punto del botón +

                ///SQL
                //Sql sql = new Sql();
                //if (sql.Guardar(listPatente))
                //{
                //    MessageBox.Show("¡Patentes guardadas en la base de datos!", Text, MessageBoxButtons.OK);
                //}
                //else
                //{
                //    MessageBox.Show("¡Error al guardar en la base de datos!", Text, MessageBoxButtons.OK);
                //}
                ////XML
                Xml xml = new Xml();
                if (xml.Guardar(listPatente))
                {
                    MessageBox.Show("¡Patentes guardadas en el archivo xml!", Text, MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en el archivo xml!", Text, MessageBoxButtons.OK);
                }

                ///TXT
               Texto texto = new Texto();
                if (texto.Guardar(listPatente))
                {
                    MessageBox.Show("¡Patentes guardadas en el archivo!", Text, MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en el archivo!", Text, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde la base de datos SQL.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSql_Click(object sender, EventArgs e)
        {
            try
            {
                Sql sql = new Sql();
                patentes = sql.Leer();
                IniciarSimulacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer desde la base de datos: {ex.Message}");
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo XML.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                Xml xml = new Xml();
                patentes = xml.Leer();
                IniciarSimulacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer desde el archivo XML: {ex.Message}");
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                Texto texto = new Texto();
                patentes = texto.Leer();
                IniciarSimulacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer desde el archivo de texto: {ex.Message}");
            }
        }

        /// <summary>
        /// Inicia la simulación de visualización de patentes.
        /// </summary>
        private void IniciarSimulacion()
        {
            // Implementar el método FinalizarSimulación
            // que se encarga de finalizar todos los hilos activos
            FinalizarSimulacion();
            ProximaPatente(vistaPatente);
        }

        /// <summary>
        /// Muestra la próxima patente en la vista.
        /// </summary>
        /// <param name="vistaPatente">La vista de la patente.</param>
        private void ProximaPatente(Patentes.VistaPatente vistaPatente)
        {
            if (patentes.Count > 0)
            {
                // Inicializará un hilo parametrizado para el método MostrarPatente del objeto VistaPatente recibido.
                Thread thread = new Thread(new ParameterizedThreadStart(vistaPatente.MostrarPatente));

                //Implementar acá el manejo de hilos

                Patente patente = patentes.First();
                patentes.RemoveAt(0);

                thread.Start(patente);
                threads.Add(thread);
            }
        }

        private void FinalizarSimulacion()
        {
            // Cierrra todos los hilos de la lista, ve si estan activos y los finaliza y luego borra toda la lista
            if (threads != null && threads.Count > 0)
            {
                foreach (var thread in threads)
                {
                    if (thread.IsAlive)
                    {
                        thread.Abort();
                    }
                }
                threads.Clear();
            }
        }


        private void vistaPatente_Load(object sender, EventArgs e)
        {

        }
    }
}
