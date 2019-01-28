using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_pictionary
{
    public partial class Client : Form
    {
        Graphics graphics;
        float[] position;
        Pen pen;
        bool drawing;

        public Client()
        {
            InitializeComponent();
            graphics = panel1.CreateGraphics();
            position = new float[4];
            pen = new Pen(Color.Black, 3);
            drawing = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            position[2] = e.X;
            position[3] = e.Y;
            if (drawing)
            {
                graphics.DrawLine(pen, position[0], position[1], position[2], position[3]);
            }
            position[0] = position[2];
            position[1] = position[3];
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            pen.Color = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (pen.Width)
            {
                case 3:
                    pen.Width = 5;
                    button3.Text = "Largeur : " + pen.Width;
                    break;
                case 5:
                    pen.Width = 8;
                    button3.Text = "Largeur : " + pen.Width;
                    break;
                case 8:
                    pen.Width = 3;
                    button3.Text = "Largeur : " + pen.Width;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }
    }
}
