using System;
using System.Windows.Forms;

namespace gandalf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;

            BeepBeep.On();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BeepBeep.Off();
        }
    }
}
