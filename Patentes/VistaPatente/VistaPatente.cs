using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Patentes
{
    public delegate void FinExposicionPatente(VistaPatente vistaPatente);
    public delegate void MostrarPatente(object patente);
    public partial class VistaPatente : UserControl
    {
        public event FinExposicionPatente finExposicion;

        public VistaPatente()
        {
            InitializeComponent();
            picPatente.Image = fondosPatente.Images[(int)ETipo.MERCOSUR];
        }

        public void MostrarPatente(object patente)
        {
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    // Llama al hilo principal para actualizar la interfaz de usuario.
                    Invoke(new MostrarPatente(MostrarPatente), new object[] { patente });
                }
                catch (Exception) { }
            }
            else
            {
                // Actualiza la interfaz de usuario en el hilo principal.
                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();

                // Espera y dispara el evento finExposicion después de la actualización de la interfaz de usuario.
                Thread.Sleep(1500);
                finExposicion?.Invoke(this);
            }
        }
    }
}
