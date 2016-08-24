using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BICT_Student_planning;

namespace Unit_Testing_BICT_Student_Planning
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestingLogin()
        {
            var testlogin = new Login { username = "test", password = "test" };
            Assert.AreEqual("test", testlogin.username);
            Assert.AreEqual("test", testlogin.password);
        }
    }
}
