using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Questao5_Data.Domain.Entities
{
    [Table("contacorrente")]
    public class ContaCorrente
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

        [Display(Name = "Saldo")]
        public decimal Saldo { get; set; }

    }
}
