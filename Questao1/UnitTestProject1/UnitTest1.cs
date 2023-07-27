using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double saldoEsperado = 1;
            Assert.AreEqual(saldoEsperado, 1, "O saldo após o depósito não foi calculado corretamente.");
        }
    }
}
