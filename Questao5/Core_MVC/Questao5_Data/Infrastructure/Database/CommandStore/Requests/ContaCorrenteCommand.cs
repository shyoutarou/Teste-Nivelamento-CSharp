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


        public void AddContaCorrente(ContaCorrente contacorrente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                connection.Execute(@"INSERT INTO contacorrente (IdContaCorrente, Numero, Nome, Ativo)
                                 VALUES (@IdContaCorrente, @Numero, @Nome, @Ativo)",
                                     contacorrente);
            }
        }

        public void DeleteContaCorrente(int id)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                connection.Execute(@"DELETE contacorrente WHERE IdContaCorrente = @IdContaCorrente", id);
            }
        }

        public bool UpdateContaCorrente(ContaCorrente contacorrente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                connection.Execute(@"UPDATE contacorrente SET
                                       Nome = @Nome, 
                                       Ativo = @Ativo
                                      WHERE IdContaCorrente = @IdContaCorrente ", contacorrente);

                return true;
            }
        }


    }
}
