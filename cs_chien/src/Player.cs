using SFML.Graphics;
using static SFML.Window.Keyboard;

namespace cs_chien
{
    class Player : Model
    {
        public Player() : base(100, 150, Color.Green)
        {
        }

        public override void Tick(int tick)
        {
            Speed.Gravity(this);

            Program program = Program.get();

            if (program.isKeyPressed(Key.Q))
            {
                MoveX(-7);
            }
            if (program.isKeyPressed(Key.D))
            {
                MoveX(7);
            }
            if (program.isKeyPressed(Key.Space))
            {
                Speed.SetY(this, -15);
            }
        }
    }
}
