using Questao5_Data.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVC_Core_Client.Models
{
    public class ContaCorrenteModel
    {
        [Key]
        [Display(Name = "ID")]
        public string IdContaCorrente { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime DtAlteracao { get; set; }

        [Display(Name = "Data de Consulta")]
        public DateTime UltimaDataMovimento { get; set; }

        public string SaldoString { get; set; }

        public double Saldo
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(SaldoString))
                {
                    CultureInfo culture = new CultureInfo("pt-BR"); // Definir a cultura correta
                    if (double.TryParse(SaldoString.Replace(",", ".").Replace(".", ","), NumberStyles.Float, culture, out double valor))
                        return valor;

                }

                return 0;
            }
            set
            {
                SaldoString = value.ToString(CultureInfo.InvariantCulture);
            }
        }




        public string CreditosString { get; set; }


        [Display(Name = "Créditos")]
        public double Creditos
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(CreditosString))
                {
                    CultureInfo culture = new CultureInfo("pt-BR"); // Definir a cultura correta
                    if (double.TryParse(CreditosString.Replace(",", ".").Replace(".", ","), NumberStyles.Float, culture, out double valor))
                        return valor;

                }

                return 0;
            }
            set
            {
                CreditosString = value.ToString(CultureInfo.InvariantCulture);
            }
        }




        [Display(Name = "Débitos")]
        public string DebitosString { get; set; }

        public double Debitos
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(DebitosString))
                {
                    CultureInfo culture = new CultureInfo("pt-BR"); // Definir a cultura correta
                    if (double.TryParse(DebitosString.Replace(",", ".").Replace(".", ","), NumberStyles.Float, culture, out double valor))
                        return valor;

                }

                return 0;
            }
            set
            {
                DebitosString = value.ToString(CultureInfo.InvariantCulture);
            }
        }


        public string IdMovimento { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }

        public string VerificacaoIdContaCorrente { get; set; }

        public static implicit operator ContaCorrente(ContaCorrenteModel model)
        {
            return new ContaCorrente
            {
                IdContaCorrente = model.IdContaCorrente,
                Numero = model.Numero,
                Nome = model.Nome,
                Ativo = model.Ativo,
                DtAlteracao = model.DtAlteracao,
                UltimaDataMovimento = model.UltimaDataMovimento,
                Saldo = model.Saldo,
            };
        }
    }
}
