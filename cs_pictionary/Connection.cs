using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace cs_pictionary
{
    public class Connection
    {
        private List<Message> messages = new List<Message>();

        private Fenetre fenetre;

        private Thread t;

        private TcpClient tcp;
        private readonly Socket cli;
        private readonly NetworkStream ns;

        public Connection(Fenetre fenetre, String host)
        {
            this.fenetre = fenetre;
            
            String[] spl = host.Split(':');
            String hostname = spl[0];
            int port = Int32.Parse(spl[1]);

            tcp = new TcpClient();
            tcp.Connect(hostname, port);
            cli = tcp.Client;
            ns = new NetworkStream(cli);

            t = new Thread(ReadThread);
            t.Start();
        }

        private void ReadThread()
        {
            try
            {
                Message msg = Message.Read(ns);
                lock (messages)
                {
                    messages.Add(msg);
                }
            }
            catch (Exception)
            {
                try
                {
                    cli.Close();
                }
                catch (Exception)
                { }
                fenetre.RemoveConnection();
            }
        }

        public void SendChat(String message)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                new Message(1, bytes).Write(ns);
            }
            catch (Exception)
            {
                try
                {
                    cli.Close();
                }
                catch (Exception)
                { }
                fenetre.RemoveConnection();
            }
        }

        public void SendLine(Line line)
        {
            try
            {
                byte[] bytes = line.Serialize();
                new Message(2, bytes).Write(ns);
            }
            catch (Exception)
            {
                try
                {
                    cli.Close();
                }
                catch (Exception)
                { }
                fenetre.RemoveConnection();
            }
        }

        public void SendClear()
        {
            try
            {
                new Message(3).Write(ns);
            }
            catch (Exception)
            {
                try
                {
                    cli.Close();
                }
                catch (Exception)
                { }
                fenetre.RemoveConnection();
            }
        }

        public void ProcessMessage()
        {
            Message msg;
            lock (messages)
            {
                if (messages.Count == 0)
                {
                    return;
                }
                msg = messages[0];
                messages.RemoveAt(0);
            }

            switch (msg.Type)
            {
                case 1:
                    String str = Encoding.UTF8.GetString(msg.Data);
                    fenetre.WriteLine(str);
                    break;

                case 2:
                    Line line = Line.Deserialize(msg.Data);
                    fenetre.PutLine(line);
                    break;

                case 3:
                    fenetre.Clear();
                    break;

                case 4:
                    fenetre.SetDrawable(true);
                    break;

                case 5:
                    fenetre.SetDrawable(false);
                    break;

                default:
                    throw new InvalidDataException("Unknown type");
            }
        }
    }
}
