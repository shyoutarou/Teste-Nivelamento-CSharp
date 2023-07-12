using System.ComponentModel.DataAnnotations;

namespace Questao5_Data.Domain.Entities
{
    public class Movimentacao
    {
        [StringLength(37, ErrorMessage = "O campo IdMovimentacao deve ter no máximo 37 caracteres.")]
        public string IdMovimentacao { get; set; }

        [StringLength(37, ErrorMessage = "O campo IdContaCorrente deve ter no máximo 37 caracteres.")]
        public string IdContaCorrente { get; set; }

        [RegularExpression("^[DC]$", ErrorMessage = "O valor deve ser 'D' ou 'C'.")]
        [Required(ErrorMessage = "O campo Tipo Movimento é obrigatório.")]
        public char TipoMovimento { get; set; }

        [RegularExpression(@"^\d{1,3}(?:\.\d{3})*(?:,\d{1,2})?$", ErrorMessage = "O campo Valor deve ser um valor válido.")]
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public decimal Valor { get; set; }



        //public string ValorString { get; set; }

        //[Range(typeof(decimal), "-9999999999", "9999999999", ErrorMessage = "O valor deve estar entre -9999999999 e 9999999999.")]

        //[RegularExpression(??????, ErrorMessage = "O campo Valor deve ser um número válido até duas casas decimais")]
        //public decimal Valor
        //{
        //    get
        //    {
        //        if(!String.IsNullOrWhiteSpace(ValorString))
        //        {
        //            if (decimal.TryParse(ValorString.Replace(",", "."), out decimal valor))
        //                return valor;
        //        }

        //        return 0;
        //    }
        //    set
        //    {
        //        ValorString = value.ToString(CultureInfo.InvariantCulture);
        //    }
        //}

    }
}
