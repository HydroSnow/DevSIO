using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex_forms
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        String fichier = null;

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if (ofd.FileName != null && ofd.FileName != "")
            {
                fichier = ofd.FileName;
                label1.Text = fichier;

                try
                {
                    textBox1.Text = File.ReadAllText(fichier)
                        .Replace("\r\n", "\n")
                        .Replace("\n", "\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.ToString(), "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fichier == null)
            {
                MessageBox.Show(
                    "Aucun fichier ouvert", "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                try
                {
                    File.WriteAllText(fichier, textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.ToString(), "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text.Length + " caractères";
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.ShowDialog();

            if (sfd.FileName != null && sfd.FileName != "")
            {
                fichier = sfd.FileName;
                label1.Text = fichier;

                try {
                    File.WriteAllText(fichier, textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.ToString(), "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void afficherLaideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Vous êtes mauvais", "Erreur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void crashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new Exception();
        }
    }
}
