using System.Net.Sockets;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    public interface ISocketBase
    {
        string IpAddress { get; set; }

        int Port { get; set; }

        void CreateSocket();
    }
}