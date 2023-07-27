using System.Globalization;

namespace Questao1_Library
{

    public class ContaBancaria
    {
        private int numero;
        private string titular;
        private double saldo;

        public ContaBancaria(int numero, string titular)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = 0;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            this.numero = numero;
            this.titular = titular;
            this.saldo = depositoInicial;
        }

        public void Deposito(double quantia)
        {
            saldo += quantia;
        }

        public void Saque(double quantia)
        {
            saldo -= quantia + 5.0;
        }

        public override string ToString()
        {
            return $"Conta {numero}, Titular: {titular}, Saldo: $ {saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
