using API_Core.Application.Queries.Requests;
using MediatR;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;

namespace ApiMediatR.Handlers
{
    public class GetIdempotenciaHandler : IRequestHandler<GetIdempotenciaRequest, IEnumerable<Idempotencia>>
    {
        private readonly IIdempotenciaQuery _idempotenciaQuery;

        public GetIdempotenciaHandler(IIdempotenciaQuery idempotenciaQuery)
        {
            _idempotenciaQuery = idempotenciaQuery;
        }

        public async Task<IEnumerable<Idempotencia>> Handle(GetIdempotenciaRequest request, CancellationToken cancellationToken)
        {
            return await _idempotenciaQuery.GetIdempotenciasAsync();
        }
    }
}
