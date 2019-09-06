using System;
using System.Threading;
using System.Windows.Forms;

namespace SafeCrossThreadUIApp
{
    public partial class Form1 : Form
    {
        private System.Threading.Timer _timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _timer = new System.Threading.Timer(UpdateTime, null, 0, 20);
        }

        private void UpdateTime(object state)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    lblTime.Text = DateTime.Now.ToString("hh:mm:ss");

                }));
            }
            catch (Exception e) when (e is ObjectDisposedException)
            {
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
