using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Sqlite;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public class MovimentacaoQuery : IMovimentacaoQuery
    {
        private readonly DatabaseConfig _databaseConfig;

        public MovimentacaoQuery(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public Movimentacao this[int id] => throw new NotImplementedException();

        public IEnumerable<Movimentacao> GetMovimentacoes()
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                
                return connection.Query<Movimentacao>("SELECT * FROM movimento");
            }
        }

        public Movimentacao GetMovimentacaoById(int idMovimenrtacao)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return connection.QuerySingleOrDefault<Movimentacao>("SELECT * FROM movimento WHERE idMovimenrtacao = @idMovimenrtacao",
                    new { idMovimenrtacao = idMovimenrtacao });
            }
        }
    }
}
