using Questao5_Data.Domain.Entities;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public interface IIdempotenciaCommand
    {
        Task<Guid> AddIdempotenciaAsync(Idempotencia idempotencia);
    }
}
