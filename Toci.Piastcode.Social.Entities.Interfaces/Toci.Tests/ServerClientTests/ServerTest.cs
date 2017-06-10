using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Piastcode.Social.Server;

namespace Toci.Tests.ServerClientTests
{
    /// <summary>
    /// Summary description for ServerTest
    /// </summary>
    [TestClass]
    public class ServerTest
    {
        public ServerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            const string ipAddress = "127.0.0.1";
            const int port = 25016;
            SocketServerManager server = new SocketServerManager(ipAddress, port);

            server.StartServer();
            //var data = Encoding.ASCII.GetBytes("Hello from the server!");

            //while (true)
            //{
            //    if (server.Clients.Count >= 3)
            //    {
            //        server.BroadcastData(data);
            //        break;
            //    }
            //}

        }
    }
}
