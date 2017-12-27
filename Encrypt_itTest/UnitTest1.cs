using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using encrypt_IT.Models;
using encrypt_IT;

namespace Encrypt_itTest
{
    [TestClass]
    public class UnitTest1
    {
        class testclass
        {

        } 

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, encrypt.caseMethod("s1"));
            Assert.AreEqual(5, encrypt.caseMethod("s5"));
            Assert.AreEqual(8, encrypt.caseMethod("s8"));
        }
    }
}
