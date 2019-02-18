using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cs_pictionary
{
    public partial class Fenetre : Form
    {
        Connection conn = null;
        List<Line> lines = new List<Line>();
        PointF[] position = new PointF[2];
        Color color = Color.Black;
        float width = 5;
        bool buttonPressed = false;
        bool disconnect = false;
        

        public Fenetre()
        {
            InitializeComponent();
            Application.Idle += new EventHandler(Fenetre_Idle);
            SetDrawable(false);
            EmptyChat();
            
        }

        public void RemoveConnection()
        {
            disconnect = true;
        }

        public void SetDrawable(bool drawable)
        {
            DrawPanel.Enabled = drawable;
            ColorButton.Enabled = drawable;
            ClearButton.Enabled = drawable;
            WidthPanel.Enabled = drawable;
        }

        public void PutLine(Line line)
        {
            lines.Add(line);
            line.Draw(DrawPanel.CreateGraphics());
        }

        public void Clear()
        {
            lines.Clear();
            GC.Collect();
            Refresh();
        }

        public void EmptyChat()
        {
            ChatBox.Text = "";
            WriteLine("Connectez-vous à un serveur en tapant l'adresse de connexion (ip:port).");
        }

        public void WriteLine(String str)
        {
            ChatBox.Text += str + "\r\n";
        }

        private void InputButton_Click(object sender, EventArgs e)
        {
            String text = InputBox.Text;
            InputBox.Clear();
            if (conn == null)
            {
                Cursor oldCursor = Cursor;
                Cursor = Cursors.WaitCursor;
                WriteLine("Connection à " + text + "...");
                try
                {
                    conn = new Connection(this, text);
                    WriteLine("Connecté !");
                }
                catch (Exception ex)
                {
                    WriteLine("Erreur : " + ex.GetType().Name);
                }
                Cursor = oldCursor;
            }
            else
            {
                try
                {
                    conn.SendChat(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                InputButton.PerformClick();
            }
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            foreach (Line line in lines)
            {
                line.Draw(e.Graphics);
            }
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            position[1] = new PointF(e.X, e.Y);
            if (buttonPressed)
            {
                Line line = new Line(position[0], position[1], color, width);
                PutLine(line);
                try
                {
                    conn.SendLine(line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            position[0] = position[1];
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            buttonPressed = true;
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            buttonPressed = false;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
            try
            {
                conn.SendClear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            DialogResult state = colorDialog1.ShowDialog();
            if (state == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
        }

        private void Width3px_CheckedChanged(object sender, EventArgs e)
        {
            if (Width3px.Checked)
            {
                width = 3;
            }
        }

        private void Width5px_CheckedChanged(object sender, EventArgs e)
        {
            if (Width5px.Checked)
            {
                width = 5;
            }
        }

        private void Width8px_CheckedChanged(object sender, EventArgs e)
        {
            if (Width8px.Checked)
            {
                width = 8;
            }
        }

        private void Width12px_CheckedChanged(object sender, EventArgs e)
        {
            if (Width12px.Checked)
            {
                width = 12;
            }
        }

        public void Fenetre_Idle(object sender, EventArgs e)
        {
            if (disconnect)
            {
                conn = null;
                SetDrawable(false);
                WriteLine("La connexion au serveur a été perdue.");
                disconnect = false;
            }

            if (conn != null)
            {
                conn.ProcessMessage();
            }
        }
    }
}
