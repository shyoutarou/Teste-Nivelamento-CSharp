using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao1_Library
{
    public interface IContaBancaria_BS
    {
        int GetNumero();
        string GetTitular();
        void SetTitular(string titular);
        double GetSaldo();
        Task DepositoAsync(double quantia); 
        Task SaqueAsync(double quantia); 
        string ToString();
    }
}
