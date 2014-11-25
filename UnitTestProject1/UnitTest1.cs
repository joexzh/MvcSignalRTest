using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Email;
using MvcSignalRTest.Common;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SendEmailMySelfTest()
        {
            EmailSender sender = new EmailSender();
            bool isSuccess = sender.SendMySelf("canvassynctest.apphb.com", "app start");
            Assert.AreEqual(true, isSuccess);
        }
    }
}
