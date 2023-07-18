using MVC_Core_Client.Models;
using Questao5_Data.Domain.Entities;

namespace MVC_Core_Client.Infrastructure.Services
{
    public interface IMovimentacaoService
    {
        Task<bool> EditarMovimentacaoAsync(Movimentacao movimentacao);

        Task<List<MovimentacaoModel>> ObterMovimentacoesAsync();
    }
}
