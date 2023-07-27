using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Questao1_Library;

namespace UnitTestProject1
{
    [TestClass]
    public class ContaBancaria_BS_Tests
    {
        [TestMethod]
        public void Test_Deposito()
        {
            // Arrange
            var conta = new ContaBancaria_BS(1, "Titular Teste");
            double valorDeposito = 100.0;

            // Act
            conta.Deposito(valorDeposito);

            // Assert
            double saldoEsperado = valorDeposito;
            Assert.AreEqual(saldoEsperado, conta.GetSaldo(), "O saldo após o depósito não foi calculado corretamente.");
        }

        [TestMethod]
        public void Test_Saque()
        {
            // Arrange
            var conta = new ContaBancaria_BS(1, "Titular Teste", 200.0);
            double valorSaque = 50.0;

            // Act
            conta.Saque(valorSaque);

            // Assert
            double saldoEsperado = 200.0 - (valorSaque + 3.5);
            Assert.AreEqual(saldoEsperado, conta.GetSaldo(), "O saldo após o saque não foi calculado corretamente.");
        }

        [TestMethod]
        public void Test_ExibirDadosConta()
        {
            // Arrange
            var conta = new ContaBancaria_BS(1, "Titular Teste", 500.0);
            string dadosEsperados = "Conta 1, Titular: Titular Teste, Saldo: $ 500.00";

            // Act
            string dadosConta = conta.ToString();

            // Assert
            Assert.AreEqual(dadosEsperados, dadosConta, "Os dados da conta não foram exibidos corretamente.");
        }


        [TestMethod]
        public void Test_CouplingWithMock()
        {
            // Arrange
            var mockConta = new Mock<IContaBancaria_BS>(); // Create a mock of IContaBancaria
            mockConta.Setup(x => x.GetSaldo()).Returns(200.0); // Setting up a mock behavior

            // Act
            double saldo = mockConta.Object.GetSaldo(); // Calling the method on the mock object

            // Assert
            double saldoEsperado = 200.0;
            Assert.AreEqual(saldoEsperado, saldo, "O saldo obtido do mock não foi o esperado.");
        }
    }
}
