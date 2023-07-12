using Questao5_Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public interface IMovimentacaoQuery
    {

        IEnumerable<Movimentacao> GetMovimentacoes();

        Movimentacao GetMovimentacaoById(int idMovimenrtacao);

    }
}
