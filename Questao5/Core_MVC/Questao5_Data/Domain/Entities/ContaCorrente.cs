using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;

namespace Questao5_Data.Domain.Entities
{
    [Table("contacorrente")]
    public class ContaCorrente
    {
        [Key]
        public string IdContaCorrente { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public string DtAlteracaoString { get; set; }

        [NotMapped]
        public DateTime DtAlteracao
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(DtAlteracaoString))
                {
                    DateTime.TryParseExact(DtAlteracaoString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtAlteracao);
                    return dtAlteracao;
                }

                return DateTime.MinValue;
            }
            set
            {
                DtAlteracaoString = value.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }


        public string UltimaDataMovimentoString { get; set; }

        [NotMapped]
        public DateTime UltimaDataMovimento
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(UltimaDataMovimentoString))
                {
                    DateTime.TryParseExact(UltimaDataMovimentoString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ultimaDataMovimento);
                    return ultimaDataMovimento;
                }

                return DateTime.MinValue;
            }
            set
            {
                UltimaDataMovimentoString = value.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        //public string UltimaDataMovimentoString { get; set; }


        //[NotMapped]
        //public DateTime UltimaDataMovimento
        //{
        //    get
        //    {
        //        if (!String.IsNullOrWhiteSpace(UltimaDataMovimentoString))
        //        {
        //            DateTime.TryParseExact(UltimaDataMovimentoString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ultimaDataMovimento);
        //            return ultimaDataMovimento;
        //        }

        //        return DateTime.MinValue;
        //    }
        //    set
        //    {
        //        UltimaDataMovimentoString = value.ToString("dd/MM/yyyy HH:mm:ss");
        //    }
        //}


        [NotMapped]
        public string SaldoString { get; set; }

 
        public double Saldo
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(SaldoString))
                {
                    if (double.TryParse(SaldoString.Replace(",", "."), out double saldo))
                        return saldo;
                }

                return 0;
            }
            set
            {
                SaldoString = value.ToString(CultureInfo.InvariantCulture);
            }
        }


        public string CreditosString { get; set; }

        [NotMapped]
        public double Creditos
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(CreditosString))
                {
                    if (double.TryParse(CreditosString.Replace(",", "."), out double creditos))
                        return creditos;
                }

                return 0;
            }
            set
            {
                CreditosString = value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string DebitosString { get; set; }


        [NotMapped]
        public double Debitos
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(DebitosString))
                {
                    if (double.TryParse(DebitosString.Replace(",", "."), out double debitos))
                        return debitos;
                }

                return 0;
            }
            set
            {
                DebitosString = value.ToString(CultureInfo.InvariantCulture);
            }
        }


        public string IdMovimento { get; set; }
    }
}
