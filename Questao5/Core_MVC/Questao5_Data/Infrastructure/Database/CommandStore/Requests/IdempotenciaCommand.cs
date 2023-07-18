using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Sqlite;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public class IdempotenciaCommand : IIdempotenciaCommand
    {
        private readonly DatabaseConfig _databaseConfig;

        public IdempotenciaCommand(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }


        public async Task<Guid> AddIdempotenciaAsync(Idempotencia idempotencia)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    var dataMovimento = DateTime.Now.ToString(); // Obtém a data e hora atual

                    await connection.ExecuteAsync(@"INSERT INTO idempotencia  (chave_idempotencia, requisicao, resultado)
                                                VALUES (@ChaveIdempotencia, @Requisicao, @Resultado)",
                                                new
                                                {
                                                    idempotencia.ChaveIdempotencia,
                                                    idempotencia.Requisicao,
                                                    idempotencia.Resultado
                                                });


                    return new Guid(idempotencia.ChaveIdempotencia);
                }
            }
            catch (Exception ex)
            {
                // Tratar o erro ou lançar exceção adequada
                throw new Exception("Ocorreu um erro ao adicionar a movimentação.", ex);
            }
        }
    }
}
