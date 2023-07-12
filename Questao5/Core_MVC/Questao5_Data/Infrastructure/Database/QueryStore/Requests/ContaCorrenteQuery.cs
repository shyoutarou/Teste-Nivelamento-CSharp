using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Sqlite;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public class ContaCorrenteQuery : IContaCorrenteQuery
    {
        private readonly DatabaseConfig _databaseConfig;

        public ContaCorrenteQuery(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public IEnumerable<ContaCorrente> GetAllContasCorrentes()
        {
            List<ContaCorrente> lstContaCorrente = new List<ContaCorrente>();
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT IdContaCorrente, Numero, Nome, Ativo FROM contacorrente";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ContaCorrente contaCorrente = new ContaCorrente();
                        contaCorrente.IdContaCorrente = reader.GetString(0);
                        contaCorrente.Numero = reader.GetInt32(1);
                        contaCorrente.Nome = reader.GetString(2);
                        contaCorrente.Ativo = reader.GetBoolean(3);
                        lstContaCorrente.Add(contaCorrente);
                    }
                }

                connection.Close();
            }

            return lstContaCorrente;
        }


        public IEnumerable<ContaCorrente> GetAllContasCorrentes_Simples()
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return connection.Query<ContaCorrente>("SELECT * FROM contacorrente");
            }
        }

        public ContaCorrente GetContaCorrenteById(string idContaCorrente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                return connection.QuerySingleOrDefault<ContaCorrente>("SELECT * FROM contacorrente WHERE IdContaCorrente = @IdContaCorrente",
                    new { IdContaCorrente = idContaCorrente });
            }
        }
    }
}
