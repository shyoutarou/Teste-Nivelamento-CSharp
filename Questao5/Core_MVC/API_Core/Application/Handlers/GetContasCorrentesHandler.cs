using API_Core.Application.Queries.Requests;
using MediatR;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;

namespace ApiMediatR.Handlers
{
    public class GetContasCorrentesHandler : IRequestHandler<GetContasCorrentesRequest, IEnumerable<ContaCorrente>>
    {
        private readonly IContaCorrenteQuery _contaCorrenteQuery;

        public GetContasCorrentesHandler(IContaCorrenteQuery contaCorrenteQuery)
        {
            _contaCorrenteQuery = contaCorrenteQuery;
        }

        public async Task<IEnumerable<ContaCorrente>> Handle(GetContasCorrentesRequest request, CancellationToken cancellationToken)
        {
            return await _contaCorrenteQuery.GetAllContasCorrentesAsync();
        }
    }
}
