using Questao5_Data.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Saldo")]
        public decimal Saldo { get; set; }

        [Display(Name = "Créditos")]
        public decimal Creditos { get; set; }
        [Display(Name = "Débitos")]
        public decimal Debitos { get; set; }

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
