using BlindTest.capsule;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace BlindTest.client
{
    class Client
    {
        private static Client instance;

        public static void Pass()
        {
            instance = new Client();
            instance.Start();
        }

        public static Client Get()
        {
            return instance;
        }
        
        private string name;
        private CapsuleSocket cs;

        private Client()
        {
            bool valid = false;
            while (!valid)
            {
                Console.Write("Entre ton nom : ");
                name = Console.ReadLine();

                if (new Regex("[^a-zA-Z0-9_-]").Match(name).Success)
                {
                    Console.WriteLine("Ton nom doit contenir seulement des lettres, chiffres, tirets et tirets du bas.");
                }
                else if (name.Length > 16)
                {
                    Console.WriteLine("Ton nom ne doit pas être de plus de 16 caractères.");
                }
                else if (name.Length < 3)
                {
                    Console.WriteLine("Ton nom ne doit pas être de moins de 3 caractères.");
                }
                else
                {
                    valid = true;
                }
            }

        }

        private void Start()
        {
            Console.Write("Entre l'adresse du serveur : ");
            string ip = Console.ReadLine();

            Console.WriteLine(" - Connexion...");
            TcpClient cli = new TcpClient(ip, 55032);
            cs = new CapsuleSocket(cli.GetStream());

            Console.WriteLine(" - Négociation...");
            Capsule neg_info = new Capsule()
            {
                Head = "NEGOCIATION",
                Data = new string[] {
                    "BTPV2",
                    name
                }
            };
            cs.WriteCapsule(neg_info);

            Capsule neg_reply = cs.ReadCapsule();
            if (neg_reply.Head == "OK")
            {
                Thread thread = new Thread(Network);
                thread.Start();

                Input();
            }
            else
            {
                Console.WriteLine("Erreur : Le serveur a refusé la requête");
                Console.WriteLine("Capsule : " + neg_reply);
            }
            
            cs.Close();
        }

        private void Input()
        {
            while (true)
            {
                string str = Console.ReadLine();
                Capsule capsule = new Capsule()
                {
                    Head = "INPUT",
                    Data = new string[] {
                        str
                    }
                };
                cs.WriteCapsule(capsule);
            }
        }

        private void ReceiveCapsule(Capsule capsule)
        {
            if (capsule.Head == "MESSAGE")
            {
                Console.WriteLine(capsule.Data[0]);
            }
            else if (capsule.Head == "MUSIC")
            {
                string b64 = capsule.Data[0];
                byte[] bytes = Convert.FromBase64String(b64);
                MusicPlayer.PlayMusicAsync(bytes);
            }
        }

        private void Network()
        {
            while (true)
            {
                try
                {
                    if (cs.IsClosed()) throw new Exception();
                    Capsule capsule = cs.ReadCapsule();
                    ReceiveCapsule(capsule);
                }
                catch (Exception)
                {
                    try
                    {
                        cs.Close();
                    }
                    catch (Exception)
                    {
                        //let it fail, LET IT FAIIIL
                    }
                    Console.WriteLine("Connection lost.");
                    break;
                }
            }
        }
    }
}
