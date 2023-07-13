using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Sqlite;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public class MovimentacaoCommand : IMovimentacaoCommand
    {
        private readonly DatabaseConfig _databaseConfig;

        public MovimentacaoCommand(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }


        public async Task AddMovimentacaoAsync(Movimentacao movimentacao)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    var dataMovimento = DateTime.Now.ToString(); // Obtém a data e hora atual

                    await connection.ExecuteAsync(@"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, valor, tipomovimento)
                                                VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @Valor, @TipoMovimento)",
                                                new
                                                {
                                                    movimentacao.IdMovimento,
                                                    movimentacao.IdContaCorrente,
                                                    DataMovimento = dataMovimento,
                                                    movimentacao.Valor,
                                                    movimentacao.TipoMovimento
                                                });
                }
            }
            catch (Exception ex)
            {
                // Tratar o erro ou lançar exceção adequada
                throw new Exception("Ocorreu um erro ao adicionar a movimentação.", ex);
            }
        }

        public async Task<bool> UpdateMovimentacaoAsync(Movimentacao movimentacao)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    await connection.ExecuteAsync(@"UPDATE movimento SET
                                               Valor = @Valor, 
                                               TipoMovimento = @TipoMovimento
                                               WHERE IdContaCorrente = @IdContaCorrente", movimentacao);

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Tratar o erro ou lançar exceção adequada
                throw new Exception("Ocorreu um erro ao atualizar a movimentação.", ex);
            }
        }

        public async Task DeleteMovimentacaoAsync(int id)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    await connection.ExecuteAsync(@"DELETE FROM movimento WHERE IdContaCorrente = @IdContaCorrente", new { IdContaCorrente = id });
                }
            }
            catch (Exception ex)
            {
                // Tratar o erro ou lançar exceção adequada
                throw new Exception("Ocorreu um erro ao excluir a movimentação.", ex);
            }
        }
    }
}
