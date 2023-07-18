using API_Core.Application.Queries.Requests;
using MediatR;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;

namespace ApiMediatR.Handlers
{
    public class GetMovimentacoesHandler : IRequestHandler<GetMovimentacoesRequest, IEnumerable<Movimentacao>>
    {
        private readonly IMovimentacaoQuery _movimentacaoQuery;

        public GetMovimentacoesHandler(IMovimentacaoQuery movimentacaoQuery)
        {
            _movimentacaoQuery = movimentacaoQuery;
        }

        public async Task<IEnumerable<Movimentacao>> Handle(GetMovimentacoesRequest request, CancellationToken cancellationToken)
        {
            return await _movimentacaoQuery.GetMovimentacoesAsync();
        }
    }
}
