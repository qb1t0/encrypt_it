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

        [TestMethod]
        public void DatabaseTestMethod()
        {
            Customer c0 = new Customer(0, 0, 0);
            Customer c1 = new Customer(1, 1, 1);
            Customer c5 = new Customer(0, 5, 5);

            Assert.AreEqual("", c0.caseMethod());
            Assert.AreEqual("3DES", c1.caseMethod());
            Assert.AreEqual("IDEA", c5.caseMethod());

        }
    }
}
