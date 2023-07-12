using Questao5_Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public interface IMovimentacaoCommand
    {
        void AddMovimentacao(Movimentacao movimentacao);

        bool UpdateMovimentacao(Movimentacao movimentacao);
        void DeleteMovimentacao(int id);

    }
}
