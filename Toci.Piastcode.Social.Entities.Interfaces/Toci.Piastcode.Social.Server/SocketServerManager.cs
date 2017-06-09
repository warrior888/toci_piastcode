using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Threading.Tasks;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets;
using Toci.Piastcode.Social.Sockets.Connection;

namespace Toci.Piastcode.Social.Server
{
    public class SocketServerManager : SocketBase
    {
        public static object LockObject = new object();

        protected List<Socket> Clients;

        public SocketServerManager(string ipAddress, int port) : base(ipAddress, port)
        {
            Clients = new List<Socket>();
            Task.Factory.StartNew(AcceptConnection);
        }

        void BroadcastData(byte[] data)
        {
            lock (LockObject)
            {
                foreach (var client in Clients)
                {
                    var connection = new SocketFrameConnection(client);
                    connection.SendData(data);
                }
            }
        }

        void AcceptConnection()
        {
            while(true)
            {
                socket.Listen(5);
                IUser user = new User();

                lock (LockObject)
                {
                    Clients.Add(socket.Accept());
                }
            }
        }

    }
}