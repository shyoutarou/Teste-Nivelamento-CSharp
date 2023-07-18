using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Core_Client.Models
{
    public class IdempotenciaModel
    {
        [Display(Name = "ID")]
        public string ChaveIdempotencia { get; set; }

        [Display(Name = "Requisição")]
        public string Requisicao { get; set; }

        [Display(Name = "Resultado")]
        public string Resultado { get; set; }
    }

}
