using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Sqlite;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public class IdempotenciaQuery : IIdempotenciaQuery
    {
        private readonly DatabaseConfig _databaseConfig;

        public IdempotenciaQuery(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

         public async Task<Idempotencia> GetIdempotenciaByKeyAsync(string chaveIdempotencia)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return await connection.QuerySingleOrDefaultAsync<Idempotencia>("SELECT * FROM idempotencia WHERE chave_idempotencia = @ChaveIdempotencia",
                    new { ChaveIdempotencia = chaveIdempotencia });
            }
        }

        public async Task<IEnumerable<Idempotencia>> GetIdempotenciasAsync()
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                var queryResult = await connection.QueryAsync<Idempotencia>("SELECT chave_idempotencia AS ChaveIdempotencia, requisicao, resultado FROM idempotencia");

                var idempotencias = queryResult.Select(row => new Idempotencia
                {
                    ChaveIdempotencia = row.ChaveIdempotencia,
                    Requisicao = row.Requisicao,
                    Resultado = row.Resultado
                });

                return idempotencias;
            }
        }
    }
}
