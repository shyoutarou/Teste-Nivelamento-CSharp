using Questao5_Data.Domain.Entities;

namespace MVC_Core_Client.Infrastructure.Services
{
    public interface IMovimentacaoService
    {
        Task<bool> EditarMovimentacaoAsync(Movimentacao movimentacao);
    }
}
