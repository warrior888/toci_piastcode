using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Piastcode.Social.Server;

namespace Toci.Piastcode.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ipAddress = "127.0.0.1";
            const int port = 25016;
            SocketServerManager server = new SocketServerManager(ipAddress, port);

            server.StartServer();
        }
    }
}
