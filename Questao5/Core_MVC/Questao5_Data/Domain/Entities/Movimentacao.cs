﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Questao5_Data.Domain.Entities
{
    public class Movimentacao
    {
        [StringLength(37, ErrorMessage = "O campo IdMovimento deve ter no máximo 37 caracteres.")]
        public string IdMovimento { get; set; }

        [StringLength(37, ErrorMessage = "O campo IdContaCorrente deve ter no máximo 37 caracteres.")]
        public string IdContaCorrente { get; set; }

        [RegularExpression("^[DC]$", ErrorMessage = "O valor deve ser 'D' ou 'C'.")]
        [Required(ErrorMessage = "O campo Tipo Movimento é obrigatório.")]
        public char TipoMovimento { get; set; }


        [RegularExpression(@"^\d{1,3}(?:\.\d{3})*(?:,\d{1,2}|\.\d{1,2})?$", ErrorMessage = "O campo Valor deve ser um valor válido.")]
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public string ValorString { get; set; }



        public double Valor
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(ValorString))
                {
                    CultureInfo culture = new CultureInfo("pt-BR");
                    NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands;

                    // Fazer a substituição apenas dos separadores de milhar
                    string valorStringFormatted = ValorString.Replace(".", "");

                    if (double.TryParse(valorStringFormatted, style, culture, out double valor))
                        return valor;


                    //CultureInfo culture = new CultureInfo("pt-BR");
                    //NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands;
                    //if (double.TryParse(ValorString.Replace(",", ".").Replace(".", ","), style, culture, out double valor))
                    //    return valor;
                }

                return 0;
            }
            set
            {
                ValorString = value.ToString("N2", CultureInfo.CurrentCulture);
            }
        }

    }
}
