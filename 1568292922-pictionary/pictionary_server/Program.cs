using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace cs_pictionary_server
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Program program = new Program();
        }

        private readonly List<User> users;
        private readonly GameManager manager;
        private Socket socket;
        private Thread t_u;
        private Thread t_h;

        private Program()
        {
            users = new List<User>();
            manager = new GameManager(this);

            t_u = new Thread(AcceptUserThread);
            t_u.Start();

            t_h = new Thread(HeartbeatUserThread);
            t_h.Start();
        }

        public void AcceptUserThread()
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 23666);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ip);
            socket.Listen(10);
            
            while (true)
            {
                try
                {
                    Socket usrsock = socket.Accept();
                    User user = new User(this, usrsock);
                    AddUser(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void HeartbeatUserThread()
        {
            Message msg = new Message(6);

            while (true)
            {
                try
                {
                    lock (users)
                    {
                        foreach (User user in users)
                        {
                            user.SendMessage(msg);
                        }
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void AddUser(User user)
        {
            lock (users)
            {
                users.Add(user);
            }
            
            String text = "Un utilisateur s'est connecté.";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            Message msg = new Message(1, bytes);
            BroadcastMessage(msg);
        }

        public void RemoveUser(User user)
        {
            lock (users)
            {
                users.Remove(user);
            }

            String text = user.Pseudo + " s'est déconnecté.";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            Message msg = new Message(1, bytes);
            BroadcastMessage(msg);
        }

        public void BroadcastMessage(Message msg, params User[] exceptions)
        {
            List<User> remove = new List<User>();
            lock (users)
            {
                foreach (User user in users)
                {
                    try
                    {
                        bool except = false;
                        foreach (User ex in exceptions)
                        {
                            if (user == ex)
                            {
                                except = true;
                                break;
                            }
                        }

                        if (!except)
                        {
                            user.SendMessage(msg);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        remove.Add(user);
                    }
                }
            }

            foreach (User user in remove)
            {
                user.Close();
            }
        }
    }
}
