using SFML.Graphics;
using SFML.System;

namespace cs_chien
{
    abstract class Model
    {
        protected RectangleShape drawable;

        public Model(float width, float height, Color color)
        {
            drawable = new RectangleShape()
            {
                Size = new Vector2f(width, height),
                FillColor = color
            };
        }

        public float GetX()
        {
            return drawable.Position.X;
        }

        public void MoveX(float deltax)
        {
            Vector2f pos = drawable.Position;
            drawable.Position = new Vector2f(pos.X + deltax, pos.Y);
        }

        public float GetY()
        {
            return drawable.Position.Y;
        }

        public void MoveY(float deltay)
        {
            Vector2f pos = drawable.Position;
            drawable.Position = new Vector2f(pos.X, pos.Y + deltay);
        }

        public abstract void Tick(int tick);

        public void Draw(RenderWindow window)
        {
            window.Draw(drawable);
        }
    }
}
