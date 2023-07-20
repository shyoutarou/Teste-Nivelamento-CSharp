using Questao5_Data.Domain.Entities;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public interface IMovimentacaoQuery
    {
        Task<IEnumerable<Movimentacao>> GetMovimentacoesAsync();
         Task<Movimentacao> GetMovimentacaoByIdAsync(int idMovimenrtacao);
    }
}
