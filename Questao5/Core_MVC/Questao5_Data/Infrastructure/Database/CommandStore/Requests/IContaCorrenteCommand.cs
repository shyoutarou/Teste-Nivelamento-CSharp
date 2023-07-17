using Questao5_Data.Domain.Entities;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public interface IContaCorrenteCommand
    {
        Task AddContaCorrenteAsync(ContaCorrente movimentacao);

        Task<bool> UpdateContaCorrenteAsync(ContaCorrente movimentacao);

        Task DeleteContaCorrenteAsync(string id);
    }
}
