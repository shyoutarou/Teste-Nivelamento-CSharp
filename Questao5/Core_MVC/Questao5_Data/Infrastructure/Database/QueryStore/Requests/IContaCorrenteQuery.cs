using Questao5_Data.Domain.Entities;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public interface IContaCorrenteQuery
    {
        IEnumerable<ContaCorrente> GetAllContasCorrentes();
        IEnumerable<ContaCorrente> GetAllContasCorrentes_Simples();
        ContaCorrente GetContaCorrenteById(string idContaCorrente);

    }
}
