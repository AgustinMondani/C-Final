using System;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace FormTemporizador
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private DateTime startTime;
        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // Intervalo de 1 segundo
            timer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (isRunning)
            {
                var elapsed = DateTime.Now - startTime;
                UpdateTimeLabel(elapsed);
            }
        }

        private void UpdateTimeLabel(TimeSpan timeSpan)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateTimeLabel(timeSpan)));
            }
            else
            {
                lblTime.Text = timeSpan.ToString(@"hh\:mm\:ss");
            }
        }

        private void RunTimer()
        {
            while (isRunning)
            {
                // Mantener el bucle mientras el cronómetro esté en marcha
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            isRunning = false;
            timer.Stop();
            lblTime.Text = "00:00:00";
        }

        private async void btnStart_Click_1(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                startTime = DateTime.Now;
                timer.Start();
                await Task.Run(() => RunTimer());
            }
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            isRunning = false;
            timer.Stop();
        }
    }
}