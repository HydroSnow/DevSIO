﻿using System.IO;
using System.Net.Sockets;

namespace cs_pictionary
{
    public class Message
    {
        public static Message Read(NetworkStream ns)
        {
            int chk0 = ns.ReadByte();
            if (chk0 != 69)
            {
                throw new InvalidDataException("This isn't a good message");
            }
            
            int chk1 = ns.ReadByte();
            if (chk1 != 42)
            {
                throw new InvalidDataException("This isn't a good message");
            }
            
            byte type = (byte)ns.ReadByte();
            
            MemoryStream ms = new MemoryStream();
            bool read = true;
            bool escape = false;
            while (read)
            {
                int b = ns.ReadByte();
                if (b == -1)
                {
                    throw new EndOfStreamException("End of stream reached");
                }
                else if (escape)
                {
                    if (b == 0)
                    {
                        read = false;
                    }
                    else if (b == 255)
                    {
                        ms.WriteByte(255);
                    }
                    else
                    {
                        throw new InvalidDataException("Unknown escape code");
                    }
                    escape = false;
                }
                else
                {
                    if (b == 255)
                    {
                        escape = true;
                    }
                    else
                    {
                        ms.WriteByte((byte)b);
                    }
                }
            }

            byte[] data = ms.ToArray();
            return new Message(type, data);
        }

        public byte Type
        {
            get;
        }

        public byte[] Data
        {
            get;
        }

        private byte[] Bytes;

        public Message(byte type)
        {
            Type = type;
            Data = new byte[0];

            MemoryStream ms = new MemoryStream();
            ms.WriteByte(69);
            ms.WriteByte(42);
            ms.WriteByte(Type);
            ms.WriteByte(255);
            ms.WriteByte(0);
            Bytes = ms.ToArray();
        }

        public Message(byte type, byte[] data)
        {
            Type = type;
            Data = data;
            
            MemoryStream ms = new MemoryStream();
            ms.WriteByte(69);
            ms.WriteByte(42);
            ms.WriteByte(Type);
            foreach (byte b in Data)
            {
                if (b == 255)
                {
                    ms.WriteByte(255);
                }
                ms.WriteByte(b);
            }
            ms.WriteByte(255);
            ms.WriteByte(0);
            Bytes = ms.ToArray();
        }

        public void Write(NetworkStream ns)
        {
            lock (ns)
            {
                ns.Write(Bytes, 0, Bytes.Length);
                ns.Flush();
            }
        }
    }
}
