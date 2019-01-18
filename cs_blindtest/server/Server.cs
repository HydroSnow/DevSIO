using BlindTest.capsule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BlindTest.server
{
    class Server
    {
        private static Server instance;

        public static void Pass()
        {
            instance = new Server();
            instance.Start();
        }

        public static Server Get()
        {
            return instance;
        }

        private readonly Socket listener;
        private readonly List<User> users;
        private readonly object thing;

        private Server()
        {
            IPEndPoint ipConfig = new IPEndPoint(IPAddress.Any, 55032);
            listener = new Socket(ipConfig.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ipConfig);
            listener.Listen(10);

            users = new List<User>();
            thing = new object();
        }

        private void Start()
        {
            Thread thread = new Thread(Network);
            thread.Start();

            Input();

            thread.Abort();
            listener.Close();
        }

        public void AddUser(User user)
        {
            lock (thing)
            {
                users.Add(user);
            }
            BroadcastMessage(" [+] " + user + " s'est connecté");
        }

        public void RemoveUser(User user)
        {
            lock (thing)
            {
                users.Remove(user);
            }
            BroadcastMessage(" [-] " + user + " s'est déconnecté");
        }

        public void BroadcastCapsule(Capsule capsule)
        {
            lock (thing)
            {
                foreach (User user in users)
                {
                    user.SendCapsule(capsule);
                }
            }
        }

        public void BroadcastMessage(string message)
        {
            lock (thing)
            {
                foreach (User user in users)
                {
                    user.SendMessage(message);
                }
            }
            Console.WriteLine(message);
        }

        public void ReceiveCapsule(User user, Capsule capsule)
        {
            try
            {
                if (capsule.Head == "INPUT")
                {
                    string input = capsule.Data[0];

                    if (input.StartsWith("/"))
                    {
                        string[] split = input.Split(' ');

                        if (split[0] == "/help")
                        {
                            if (split.Length == 1)
                            {
                                string str = " Voici la liste des commandes disponibles :";
                                str += "\n - /help : Afficher ce message";
                                user.SendMessage(str);
                            }
                            else
                            {
                                user.SendMessage(" Syntaxe incorrecte : /help");
                            }
                        }
                        else
                        {
                            user.SendMessage(" Commande inconnue. Tape /help pour obtenir une liste de commandes.");
                        }
                    }
                    else
                    {
                        BroadcastMessage(" <" + user + "> " + input);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("   Erreur lors du traitement d'une capsule utilisateur");
                Console.WriteLine("   Utilisateur : " + user);
                Console.WriteLine("   Capsule : " + capsule);
                Console.WriteLine("   Exception : " + e);
            }
        }

        private void Input()
        {
            while (true)
            {
                string input = Console.ReadLine();
                
                try
                {
                    if (input.StartsWith("/"))
                    {
                        string[] split = input.Split(' ');

                        if (split[0] == "/play")
                        {
                            if (split.Length == 2)
                            {
                                byte[] bytes = File.ReadAllBytes(split[1]);
                                Capsule capsule = new Capsule()
                                {
                                    Head = "MUSIC",
                                    Data = new string[] {
                                        Convert.ToBase64String(bytes)
                                    }
                                };
                                BroadcastCapsule(capsule);
                            }
                            else
                            {
                                Console.WriteLine(" Syntaxe incorrecte : /play [musique]");
                            }
                        }
                        else if (split[0] == "/help")
                        {
                            if (split.Length == 1)
                            {
                                string str = " Voici la liste des commandes disponibles :";
                                str += "\n - /play : Jouer une musique";
                                str += "\n - /help : Afficher ce message";
                                Console.WriteLine(str);
                            }
                            else
                            {
                                Console.WriteLine(" Syntaxe incorrecte : /help");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Commande inconnue. Tape /help pour obtenir une liste de commandes.");
                        }
                    }
                    else
                    {
                        BroadcastMessage(" [server] " + input);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("   Erreur lors du traitement d'une requête serveur");
                    Console.WriteLine("   Requête : " + input);
                    Console.WriteLine("   Exception : " + e);
                }
            }
        }

        private void Network()
        {
            while (true)
            {
                try
                {
                    Socket socket = listener.Accept();
                    IPEndPoint ipinfo = (IPEndPoint)socket.RemoteEndPoint;
                    try
                    {
                        User client = new User(socket);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("   Erreur lors de la connexion d'un utilisateur");
                        Console.WriteLine("   Utilisateur : " + ipinfo.Address + ":" + ipinfo.Port);
                        Console.WriteLine("   Exception : " + e);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("   Erreur lors de la connexion d'un utilisateur");
                    Console.WriteLine("   Exception : " + e);
                }
            }
        }
    }
}
