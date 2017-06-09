using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Piastcode.VoiceRecognition.Poc.Audio2Text;

namespace Toci.Piastcode.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MicPoc poc = new MicPoc();

            poc.MicPocTest();

            while (true)
            {
                Thread.Sleep(1);
            }
        }
    }
}
