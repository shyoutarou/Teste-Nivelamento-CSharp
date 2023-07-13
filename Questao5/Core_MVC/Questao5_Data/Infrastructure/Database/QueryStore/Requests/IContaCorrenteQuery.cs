using Questao5_Data.Domain.Entities;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public interface IContaCorrenteQuery
    {
        Task<IEnumerable<ContaCorrente>> GetAllContasCorrentesAsync();
        Task<IEnumerable<ContaCorrente>> GetAllContasCorrentes_SimplesAsync();

        Task<ContaCorrente> GetContaCorrenteAsync(int numeroConta);

        Task<ContaCorrente> GetContaCorrenteByIdAsync(string idContaCorrente);

    }
}
