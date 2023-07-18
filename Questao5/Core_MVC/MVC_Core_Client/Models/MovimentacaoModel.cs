using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVC_Core_Client.Models
{
    public class MovimentacaoModel
    {
        [Display(Name = "ID")]
        public string IdMovimento { get; set; }

        [Display(Name = "Conta")]
        public string IdContaCorrente { get; set; }

        [Display(Name = "Tipo Movimento")]
        public char TipoMovimento { get; set; }


        public string ValorString { get; set; }

        public double Valor
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(ValorString))
                {
                    CultureInfo culture = new CultureInfo("pt-BR"); // Definir a cultura correta
                    if (double.TryParse(ValorString.Replace(",", ".").Replace(".", ","), NumberStyles.Float, culture, out double valor))
                        return valor;
                }

                return 0;
            }
            set
            {
                ValorString = value.ToString(CultureInfo.InvariantCulture);
            }
        }

    }
}
