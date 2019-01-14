using BlindTest.client;
using BlindTest.server;
using System;

namespace BlindTest
{
    class Starter
    {
        private static bool server = false;

        public static void Main(string[] args)
        {
            try
            {
                foreach (string str in args)
                {
                    if (str.ToLower() == "--server")
                    {
                        server = true;
                        break;
                    }
                    else if (str.ToLower() == "--client")
                    {
                        server = false;
                        break;
                    }
                }

                if (server)
                {
                    Server.Pass();
                }
                else
                {
                    Client.Pass();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.WriteLine("Arrêt du programme dans 10 secondes...");
            System.Threading.Thread.Sleep(10000);
        }
    }
}
