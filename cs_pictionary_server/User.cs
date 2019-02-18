using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace cs_pictionary_server
{
    public class User
    {
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

            byte[] bytes = new byte[24];
            Buffer.BlockCopy(BitConverter.GetBytes(0f), 0, bytes, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(0f), 0, bytes, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(200f), 0, bytes, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(200f), 0, bytes, 12, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(0), 0, bytes, 16, 3);
            Buffer.BlockCopy(BitConverter.GetBytes(30f), 0, bytes, 20, 4);

            Message msg2 = new Message(2, bytes);
            msg2.Write(ns);

            t = new Thread(ReadThread);
            t.Start();
        }

        public void Remove()
        {
            t.Abort();
            try
            {
                cli.Close();
            }
            catch (Exception)
            { }
        }

        public void SendMessage(Message msg)
        {
            msg.Write(ns);
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
                            program.BroadcastMessage(msg);
                            break;

                        case 2:
                        case 3:
                            program.BroadcastMessage(msg, this);
                            break;

                        default:
                            throw new InvalidDataException("Unknown type");
                    }
                }
            }
            catch (ThreadAbortException)
            { }
            catch (Exception)
            {
                try
                {
                    cli.Close();
                }
                catch (Exception)
                { }

                program.RemoveUser(this);
            }
        }
    }
}
