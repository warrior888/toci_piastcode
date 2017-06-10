using System;
using System.Net;
using System.Net.Sockets;
using Toci.Piastcode.Common.Interfaces;

namespace Toci.Piastcode.Social.Sockets
{
    public class SocketClientBase : SocketBase
    {
        public SocketClientBase(string ipAddress, int port) : base(ipAddress, port)
        {
            CreateSocket();
        }

        public override void CreateSocket()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);
        }

        public void AddFile(Action<IProjectItem> action, IProjectItem projectItem)
        {
            action(projectItem);
        }
    }
}