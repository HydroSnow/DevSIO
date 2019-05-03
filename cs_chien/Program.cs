using System;
using System.Diagnostics;
using System.Threading;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace cs_chien
{
    class Chien
    {
        private const int TICKS_PER_SECOND = 60;
        private const double TICK_MILLISECONDS = 1000 / TICKS_PER_SECOND;
        private static Chien chien;

        public static void Main(string[] args)
        {
            Console.WriteLine("STA> Starting application..");
            chien = new Chien();
            chien.init();
            chien.loop();
        }

        VideoMode mode = new VideoMode(800, 600);
        RenderWindow window;

        private Chien()
        {
            Console.WriteLine("STA> Initializing game loop object..");
        }

        private void init()
        {
            Console.WriteLine("STA> Creating window..");
            window = new RenderWindow(mode, "SFML works!");
            
        }

        private void loop()
        {
            Console.WriteLine("STA> Creating circle..");
            CircleShape shape = new CircleShape(100)
            {
                FillColor = Color.Green
            };
            window.Closed += onClose;

            Console.WriteLine("STA> Starting loop..");
            while (window.IsOpen)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                window.Clear();
                window.Draw(shape);
                window.Display();
                window.DispatchEvents();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                
                if (TICK_MILLISECONDS > ts.TotalMilliseconds)
                {
                    double result = TICK_MILLISECONDS - ts.TotalMilliseconds;
                    int resint = (int) result;
                    Thread.Sleep(resint);
                }
                else
                {
                    Console.WriteLine("Can't keep up!");
                }
            }
        }

        private void onClose(object sender, EventArgs args)
        {
            window.Close();
        }
    }
}
