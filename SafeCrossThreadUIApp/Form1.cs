using System;
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
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
