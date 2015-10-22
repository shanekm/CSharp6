using System;
using AutoPropertyInitialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AutoPropertyInitialization
    {
        [TestMethod]
        public void TestMethod1()
        {
            var u1 = new User();
            Assert.AreNotEqual(Guid.Empty, u1.Id);
        }
    }
}