using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bouton1_ajouter_Click(object sender, EventArgs e)
        {
            input1.Text = input1.Text + textbox1.Text;
            textbox1.Clear();
        }

        private void bouton2_ajouter_Click(object sender, EventArgs e)
        {
            input2.Text = input2.Text + textbox2.Text;
            textbox2.Clear();
        }

        private void droite_Click(object sender, EventArgs e)
        {
            input2.Text = input2.Text + input1.SelectedText;
            input1.SelectedText = "";
        }

        private void droite_all_Click(object sender, EventArgs e)
        {
            input2.Text = input2.Text + input1.Text;
            input1.Clear();
        }

        private void gauche_Click(object sender, EventArgs e)
        {
            input1.Text = input1.Text + input2.SelectedText;
            input2.SelectedText = "";
        }

        private void gauche_all_Click(object sender, EventArgs e)
        {
            input1.Text = input1.Text + input2.Text;
            input2.Clear();
        }
    }
}
