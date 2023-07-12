using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria_BS
    {
        private readonly int _Numero;
        private string _Titular;
        private double _Saldo;

        public ContaBancaria_BS(int numero, string titular, double depositoInicial = 0)
        {
            _Numero = numero;
            _Titular = titular;

            if (depositoInicial > 0)
                Deposito(depositoInicial);
            else
                _Saldo = 0;
        }

        public int GetNumero() => _Numero;

        public string GetTitular()
        {
            return _Titular;
        }

        public void SetTitular(string titular)
        {
            _Titular = titular;
        }

        public double GetSaldo() => _Saldo;

        public void Deposito(double quantia)
        {
            _Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            double valorSaque = quantia + 3.5;
            _Saldo -= valorSaque;
        }

        public override string ToString()
        {
            return $"Conta {_Numero}, Titular: {_Titular}, Saldo: $ {_Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
