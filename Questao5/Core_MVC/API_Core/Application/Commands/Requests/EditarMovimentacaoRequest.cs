using MediatR;
using Questao5_Data.Domain.Entities;

namespace ApiMediatR.Handlers.Request
{
    public class EditarMovimentacaoRequest : IRequest<Guid>
    {
        public Movimentacao movimentacao { get; set; }
    }
}
