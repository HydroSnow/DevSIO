using BlindTest.capsule;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace BlindTest.server
{
    class User
    {
        private CapsuleSocket cs;
        private readonly string name;

        public User(Socket socket)
        {
            NetworkStream ns = new NetworkStream(socket);
            cs = new CapsuleSocket(ns);

            Capsule neg_info = cs.ReadCapsule();

            if (neg_info == null)
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "INVALID_CAPSULE"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("INVALID_CAPSULE");
            }

            if (neg_info.Head != "NEGOCIATION")
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "INVALID_CAPSULE"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("INVALID_CAPSULE");
            }

            if (neg_info.Data.Length != 2)
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "INVALID_CAPSULE"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("INVALID_CAPSULE");
            }

            if (neg_info.Data[0] != "BTPV2")
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "PROTOCOL_MISMATCH"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("PROTOCOL_MISMATCH");
            }

            name = neg_info.Data[1];

            if (new Regex("[^a-zA-Z0-9_-]").Match(name).Success)
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "INVALID_NAME"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("INVALID_NAME");
            }

            if (name.Length > 16)
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "INVALID_NAME"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("INVALID_NAME");
            }

            if (name.Length < 3)
            {
                Capsule capsule = new Capsule()
                {
                    Head = "ERROR",
                    Data = new string[] {
                        "INVALID_NAME"
                    }
                };
                SendCapsule(capsule);
                socket.Close();
                throw new IOException("INVALID_NAME");
            }

            {
                Capsule capsule = new Capsule()
                {
                    Head = "OK",
                    Data = new string[] {
                        "SUCCESS"
                    }
                };
                SendCapsule(capsule);
            }

            SendMessage(" - Tu es connecté.");
            
            new Thread(Network).Start();
            
            Server.Get().AddUser(this);
        }

        private void Network()
        {
            while (true)
            {
                try
                {
                    if (cs.IsClosed()) throw new Exception();
                    Capsule capsule = cs.ReadCapsule();
                    Server.Get().ReceiveCapsule(this, capsule);
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
                    Server.Get().RemoveUser(this);
                    break;
                }
            }
        }

        public override string ToString()
        {
            return name;
        }

        public void SendCapsule(Capsule capsule)
        {
            cs.WriteCapsule(capsule);
        }

        public void SendMessage(string message)
        {
            Capsule capsule = new Capsule()
            {
                Head = "MESSAGE",
                Data = new string[] {
                    message
                }
            };
            SendCapsule(capsule);
        }
    }
}
