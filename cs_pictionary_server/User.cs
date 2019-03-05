using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace cs_pictionary_server
{
    public class User
    {
        public String Pseudo
        {
            get;
            private set;
        }

        private Program program;
        private Thread t;
        private readonly Socket cli;
        private readonly NetworkStream ns;

        public User(Program program, Socket socket)
        {
            this.program = program;
            cli = socket;
            ns = new NetworkStream(cli);

            Message msg = new Message(4);
            msg.Write(ns);

            t = new Thread(ReadThread);
            t.Start();
        }

        private void ReadThread()
        {
            try
            {
                while (true)
                {
                    Message msg = Message.Read(ns);

                    switch (msg.Type)
                    {
                        case 1:
                            String str = Encoding.UTF8.GetString(msg.Data);
                            str = " " + Pseudo + " : " + str;
                            byte[] bytes = Encoding.UTF8.GetBytes(str);
                            Message paupiette = new Message(1, bytes);
                            program.BroadcastMessage(paupiette);
                            break;

                        case 2:
                        case 3:
                            program.BroadcastMessage(msg, this);
                            break;

                        case 4:
                            Pseudo = Encoding.UTF8.GetString(msg.Data);
                            break;

                        default:
                            throw new InvalidDataException("Unknown type");
                    }
                }
            }
            catch (Exception)
            {
                Close();
            }
        }

        public void Close()
        {
            try
            {
                cli.Close();
            }
            catch (Exception)
            { }
            program.RemoveUser(this);
        }

        public void SendMessage(Message msg)
        {
            try
            {
                msg.Write(ns);
            }
            catch (Exception)
            {
                Close();
            }
        }
    }
}
