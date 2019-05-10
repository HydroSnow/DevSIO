using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using static SFML.Window.Keyboard;

namespace cs_chien
{
    class Program
    {
        private const int TICKS_PER_SECOND = 60;
        private const double TICK_MILLISECONDS = 1000 / TICKS_PER_SECOND;
        private static Program program;

        public static Program get()
        {
            return program;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("STA> Starting application..");
            program = new Program();
            program.init();
            program.loop();
        }

        private VideoMode mode = new VideoMode(1024, 768);
        private RenderWindow window;
        private List<Model> models;
        private Model player;
        private Dictionary<Key, bool> keys;

        private Program()
        {
        }

        private void init()
        {
            Console.WriteLine("STA> Creating window..");

            window = new RenderWindow(mode, "SFML works!");
            window.Closed += onClose;
            window.KeyPressed += onKeyPress;
            window.KeyReleased += onKeyRelease;
            models = new List<Model>();

            player = new Player();
            models.Add(player);
            
            keys = new Dictionary<Key, bool>();
        }

        private void loop()
        {
            Console.WriteLine("STA> Starting loop..");

            int tick = 0;
            double usage = 0;

            Stopwatch stopWatch = new Stopwatch();

            while (window.IsOpen)
            {
                tick++;

                stopWatch.Reset();
                stopWatch.Start();

                window.DispatchEvents();
                foreach (Model model in models)
                {
                    model.Tick(tick);
                    Speed.TickSpeed(model);
                }
                window.Clear();
                foreach (Model model in models)
                {
                    model.Draw(window);
                }
                window.Display();

                double delta = TICK_MILLISECONDS - stopWatch.Elapsed.TotalMilliseconds;
                usage += TICK_MILLISECONDS - delta;

                if (delta > 0)
                {
                    Thread.Sleep((int) delta);
                }
                else
                {
                    Console.WriteLine(" -x> Can't keep up tick " + tick + "! " + Math.Abs(delta) + "ms behind");
                }

                if (tick % 120 == 0)
                {
                    double percentage = usage * 100 / 60 / TICK_MILLISECONDS;
                    Console.WriteLine(" -i> Usage on ticks " + (tick - 60) + " to " + tick + " is " + percentage + "%");
                    usage = 0;
                }
            }
        }

        public List<Model> getModels()
        {
            return models;
        }

        public bool isKeyPressed(Key key)
        {
            try
            {
                return keys[key];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }

        private void onKeyPress(object sender, KeyEventArgs args)
        {
            keys[args.Code] = true;
        }

        private void onKeyRelease(object sender, KeyEventArgs args)
        {
            keys[args.Code] = false;
        }

        private void onClose(object sender, EventArgs args)
        {
            window.Close();
        }
    }
}
