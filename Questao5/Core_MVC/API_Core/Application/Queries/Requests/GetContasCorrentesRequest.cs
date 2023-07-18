using MediatR;
using Questao5_Data.Domain.Entities;

namespace API_Core.Application.Queries.Requests
{
    public class GetContasCorrentesRequest : IRequest<IEnumerable<ContaCorrente>>
    {

    }
}
