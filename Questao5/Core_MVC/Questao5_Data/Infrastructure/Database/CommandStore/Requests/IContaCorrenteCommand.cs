using Questao5_Data.Domain.Entities;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public interface IContaCorrenteCommand
    {
        void AddContaCorrente(ContaCorrente movimentacao);

        bool UpdateContaCorrente(ContaCorrente movimentacao);
        void DeleteContaCorrente(int id);

    }
}
