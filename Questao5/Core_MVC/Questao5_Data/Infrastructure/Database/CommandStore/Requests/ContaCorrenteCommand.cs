using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Sqlite;

namespace Questao5_Data.Infrastructure.Database.CommandStore.Requests
{
    public class ContaCorrenteCommand : IContaCorrenteCommand
    {
        private readonly DatabaseConfig _databaseConfig;

        public ContaCorrenteCommand(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task AddContaCorrenteAsync(ContaCorrente contacorrente)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    await connection.ExecuteAsync(@"INSERT INTO contacorrente (IdContaCorrente, Numero, Nome, Ativo)
                                 VALUES (@IdContaCorrente, @Numero, @Nome, @Ativo)",
                                     contacorrente);
                }
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Ocorreu um erro ao adicionar a conta corrente.", ex);
            }
        }

        public async Task DeleteContaCorrenteAsync(string id)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    await connection.ExecuteAsync(@"DELETE contacorrente WHERE IdContaCorrente = @IdContaCorrente", id);
                }
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Ocorreu um erro ao excluir a conta corrente.", ex);
            }
        }

        public async Task<bool> UpdateContaCorrenteAsync(ContaCorrente contacorrente)
        {
            try
            {
                using (var connection = new SqliteConnection(_databaseConfig.Name))
                {
                    await connection.ExecuteAsync(@"UPDATE contacorrente SET
                                       Nome = @Nome, 
                                       Ativo = @Ativo
                                      WHERE IdContaCorrente = @IdContaCorrente ", contacorrente);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log do erro
                throw new Exception("Ocorreu um erro ao atualizar a conta corrente.", ex);
            }
        }
    }
}
