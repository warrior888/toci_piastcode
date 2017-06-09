using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Piastcode.Instructions.Tools;

namespace Toci.Tests.InstructionTest
{
    [TestClass]
    public class CreateFileTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DeveloperCommandParser test = new DeveloperCommandParser();
            test.CommandParser("public abstract class", null);

        }
    }
}
