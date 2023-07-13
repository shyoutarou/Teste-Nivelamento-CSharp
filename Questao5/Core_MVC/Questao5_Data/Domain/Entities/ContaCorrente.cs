﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

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

        public DateTime DtAlteracao { get; set; }

        public DateTime UltimaDataMovimento { get; set; }

        public double Saldo { get; set; }

        public double Creditos { get; set; }

        public double Debitos { get; set; }

        public string IdMovimento { get; set; }

    }
}
