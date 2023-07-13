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

        public async Task<IEnumerable<Movimentacao>> GetMovimentacoesAsync()
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                var queryResult = await connection.QueryAsync<Movimentacao>("SELECT idmovimento, idcontacorrente, datamovimento, tipomovimento, CAST(valor AS TEXT) AS valorString FROM movimento");

                var movimentacoes = queryResult.Select(row => new Movimentacao
                {
                    IdMovimento = row.IdMovimento,
                    IdContaCorrente = row.IdContaCorrente,
                    TipoMovimento = row.TipoMovimento,
                    ValorString = row.ValorString,
                    Valor = row.Valor
                    //Valor = decimal.TryParse(row.ValorString, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal valor) ? valor : 0
                });

                return movimentacoes;
            }
        }


        public async Task<Movimentacao> GetMovimentacaoByIdAsync(int idMovimenrtacao)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return await connection.QuerySingleOrDefaultAsync<Movimentacao>("SELECT * FROM movimento WHERE idMovimenrtacao = @idMovimenrtacao",
                    new { idMovimenrtacao = idMovimenrtacao });
            }
        }
    }
}
