using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets;

namespace toci.Piastcode.Social.Client
{
    public class SocketClientManager : SocketClientBase
    {
        public SocketClientManager(string ipAddress, int port) : base(ipAddress, port)
        {
        }

        public void StartClient()
        {
            Task.Factory.StartNew(ListenForString);
            while (true)
            {
                //Task<IFrame> task = new Task<IFrame>(ListenForFrame);
                //task.Start();


                socket.Send(Encoding.ASCII.GetBytes(Console.ReadLine()));
                

                //task.Wait();
                // TODO: Do something with that frame
                //var frame = task.Result;
            }
        }


        protected void ListenForString()
        {
            while(true)
            { 
            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }

            Console.WriteLine(Encoding.ASCII.GetString(formatted));
            }
        }

        protected IFrame ListenForFrame()
        {
            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }
            IFrame frame = new Frame();

            frame = Serializer.Deserialize<IFrame>(new MemoryStream(formatted));
            return frame;
        }

        public override void CreateSocket()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(endPoint);
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                IUser user = new User
                {
                    Name = userName,
                };
                using (MemoryStream ms = new MemoryStream())
                {
                    Serializer.Serialize(ms, user);
                    socket.Send(ms.ToArray());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Couldn't connect to the server, exception: " + ex);
            }
        }
    }
}