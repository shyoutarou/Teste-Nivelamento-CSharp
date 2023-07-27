using Questao1_Library;
using System.Globalization;
using System.Threading.Tasks;

namespace Questao1_Library
{
    public class ContaBancaria_BS : IContaBancaria_BS
    {
        private readonly int _Numero;
        private string _Titular;
        private double _Saldo;

        public ContaBancaria_BS(int numero, string titular, double depositoInicial = 0)
        {
            _Numero = numero;
            _Titular = titular;

            if (depositoInicial > 0)
                DepositoAsync(depositoInicial).Wait();  
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

        public async Task DepositoAsync(double quantia) // Adicionando o sufixo "Async"
        {
            await Task.Delay(0); // Aqui você colocaria a lógica assíncrona real, se houvesse
            _Saldo += quantia;
        }

        public async Task SaqueAsync(double quantia) // Adicionando o sufixo "Async"
        {
            await Task.Delay(0); // Aqui você colocaria a lógica assíncrona real, se houvesse
            double valorSaque = quantia + 3.5;
            _Saldo -= valorSaque;
        }

        public override string ToString()
        {
            return $"Conta {_Numero}, Titular: {_Titular}, Saldo: $ {_Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
