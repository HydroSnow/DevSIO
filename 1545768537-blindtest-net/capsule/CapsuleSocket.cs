using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Sockets;

namespace BlindTest.capsule
{
    class CapsuleSocket
    {
        private readonly NetworkStream ns;
        private readonly StreamReader sr;
        private readonly StreamWriter sw;

        public CapsuleSocket(NetworkStream networkStream)
        {
            ns = networkStream;
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns)
            {
                AutoFlush = true
            };
        }

        public Capsule ReadCapsule()
        {
            return Capsule.FromString(sr.ReadLine());
        }

        public void WriteCapsule(Capsule c) 
        {
            sw.WriteLine(c);
        }

        public void Close()
        {
            sr.Close();
            sw.Close();
            ns.Close();
        }

        public bool IsClosed()
        {
            return !(ns.CanRead && ns.CanWrite);
        }
    }
}
