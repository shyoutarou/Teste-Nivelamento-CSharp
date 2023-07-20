using MVC_Core_Client.Models;
using Questao5_Data.Domain.Entities;

namespace MVC_Core_Client.Infrastructure.Services
{
    public interface IIdempotenciaService
    {
        Task<bool> EditarIdempotenciaAsync(Idempotencia idempotencia);

        Task<List<IdempotenciaModel>> ObterIdempotenciasAsync();
    }
}
