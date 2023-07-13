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
        Task AddMovimentacaoAsync(Movimentacao movimentacao);
        Task<bool> UpdateMovimentacaoAsync(Movimentacao movimentacao);
        Task DeleteMovimentacaoAsync(int id);
    }
}
