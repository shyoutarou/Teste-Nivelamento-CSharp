using MediatR;
using Questao5_Data.Domain.Entities;

namespace ApiMediatR.Handlers.Request
{
    public class GetContasCorrentesPorIdRequest : IRequest<ContaCorrente>
    {
        public Guid CustomerId { get; set; }
    }
}
