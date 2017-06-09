using System.IO;
using System.Net.Sockets;
using ProtoBuf;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Connection
{
    public class SocketProjectConnection : SocketConnection<byte[], IProject>
    {
        public SocketProjectConnection(Socket socket) : base(socket)
        {
        }

        public override void SendData(byte[] data)
        {
            socket.Send(data);
        }

        public override IProject ReceiveData()
        {
            Socket accepted = socket.Accept();
            IProject project = new Project();

            byte[] buffer = new byte[accepted.SendBufferSize];
            int bytesRead = accepted.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }

            MemoryStream ms = new MemoryStream(formatted);

            project = Serializer.Deserialize<IProject>(ms);

            return project;
        }
    }
}