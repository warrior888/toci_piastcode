using System.Net;
using System.Net.Sockets;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Sockets
{
    public abstract class SocketBase : ISocketBase
    {
        public SocketBase(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
            CreateSocket();
        }

        protected Socket socket { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public void CreateSocket()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            socket =  new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}