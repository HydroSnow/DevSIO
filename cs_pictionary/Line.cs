using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace cs_pictionary
{
    public class Line
    {
        public static Line Deserialize(byte[] bytes)
        {
            float x1 = BitConverter.ToSingle(bytes, 0);
            float y1 = BitConverter.ToSingle(bytes, 4);
            float x2 = BitConverter.ToSingle(bytes, 8);
            float y2 = BitConverter.ToSingle(bytes, 12);
            int argb = BitConverter.ToInt32(bytes, 16);
            float wd = BitConverter.ToSingle(bytes, 20);
            return new Line(new PointF(x1, y1), new PointF(x2, y2), Color.FromArgb(argb), wd);
        }

        private PointF p1;
        private PointF p2;
        private Pen pen;

        public Line(PointF p1, PointF p2, Color cl, float wd)
        {
            this.p1 = p1;
            this.p2 = p2;
            pen = new Pen(cl, wd)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        public byte[] Serialize()
        {
            byte[] bytes = new byte[24];
            Buffer.BlockCopy(BitConverter.GetBytes(p1.X), 0, bytes, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(p1.Y), 0, bytes, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(p2.X), 0, bytes, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(p2.Y), 0, bytes, 12, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(pen.Color.ToArgb()), 0, bytes, 16, 3);
            Buffer.BlockCopy(BitConverter.GetBytes(pen.Width), 0, bytes, 20, 4);
            return bytes;
        }
    }
}
