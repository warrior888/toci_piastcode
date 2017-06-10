using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets;
using Toci.Piastcode.Social.Sockets.Connection;

namespace Toci.Piastcode.Social.Server
{
    public class SocketServerManager : SocketServerBase
    {
        public static object LockObject = new object();

        public List<IClient> Clients;

        public SocketServerManager(string ipAddress, int port) : base(ipAddress, port)
        {
            Clients = new List<IClient>();
            nameCount = 0;
        }

        public void StartServer()
        {
            Task task = new Task(AcceptConnection);
            task.Start();

            while (true)
            {
                BroadcastData(Encoding.ASCII.GetBytes(Console.ReadLine()));
            }
            //TODO: while(true) loop with some logic 

            task.Wait();
        }

        public void BroadcastData(byte[] data, IClient filteredClient = null)
        {
            lock (LockObject)
            {
                foreach (var client in Clients)
                {
                    if (filteredClient != null && filteredClient.Name == client.Name)
                    {
                        continue;
                    }
                    byte[] name = Encoding.ASCII.GetBytes(client.Name + ": ");


                    var connection = new SocketFrameConnection(client.socket);
                    connection.SendData(name.Concat(data).ToArray());
                }
            }
        }

        protected void ListenForChanges(IClient client)
        {
            while(true)
            {
                try
                {
                    byte[] buffer = new byte[client.socket.SendBufferSize];
                    int bytesRead = client.socket.Receive(buffer);

                    byte[] formatted = new byte[bytesRead];

                    for (int i = 0; i < bytesRead; i++)
                    {
                        formatted[i] = buffer[i];
                    }
                    BroadcastData(formatted, client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, exception: " + ex);
                    break;
                }
            }
        }

        public static int nameCount;

        public void AcceptConnection()
        {
            socket.Listen(5);
            while (true)
            {
                Socket accepted = socket.Accept();
                SocketUserConnection userConnection = new SocketUserConnection(accepted);
                var user = userConnection.ReceiveData();

                string[] names = {"Kunegunda", "Bdzigost", "Msciwuj", "Niebylec", "Sobiesad", "Filolog"};
                IClient client = new Client
                {
                    Name = names[nameCount],
                    socket = accepted,
                };
                
                lock (LockObject)
                {
                    
                    Clients.Add(client);
                }
                Task.Factory.StartNew(() => ListenForChanges(client));
            }
        }

    }
}