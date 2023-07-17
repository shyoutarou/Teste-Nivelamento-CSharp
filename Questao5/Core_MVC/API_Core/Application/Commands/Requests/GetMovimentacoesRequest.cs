using MediatR;
using Questao5_Data.Domain.Entities;

namespace ApiMediatR.Handlers.Request
{
    public class GetMoviemntacoesRequest : IRequest<IEnumerable<Movimentacao>> 
    {

    }
}
