using System;
using System.Threading;
using System.Windows.Forms;

namespace SafeCrossThreadUIApp
{
    public partial class Form1 : Form
    {
        private System.Threading.Timer _timer;
        private readonly SynchronizationContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = SynchronizationContext.Current ?? new SynchronizationContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _timer = new System.Threading.Timer(UpdateTime, null, 0, 20);
        }

        private void UpdateTime(object state)
        {
            //_context.Post(delegate { lblTime.Text = DateTime.Now.ToString("hh:mm:ss");}, null);
            _context.Send(delegate { lblTime.Text = DateTime.Now.ToString("hh:mm:ss"); }, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
