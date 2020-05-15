using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_a_Click(object sender, EventArgs e)
        {
            textBox1.Text += "a";
        }

        private void button_b_Click(object sender, EventArgs e)
        {
            textBox1.Text += "b";
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            textBox1.Text += "c";
        }

        private void button_effacer_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
