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


        public void AddMovimentacao(Movimentacao movimentacao)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                var dataMovimento = DateTime.Now.ToString(); // Obtém a data e hora atual

                connection.Execute(@"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, valor, tipomovimento)
                            VALUES (@IdMovimentacao, @IdContaCorrente, @DataMovimento, @Valor, @TipoMovimento)",
                                    new
                                    {
                                        movimentacao.IdMovimentacao,
                                        movimentacao.IdContaCorrente,
                                        DataMovimento = dataMovimento,
                                        movimentacao.Valor,
                                        movimentacao.TipoMovimento
                                    });
            }
        }


        public bool UpdateMovimentacao(Movimentacao movimentacao)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                connection.Execute(@"UPDATE movimento SET
                                       Valor = @Valor, 
                                       TipoMovimento = @TipoMovimento
                                      WHERE IdContaCorrente = @IdContaCorrente ", movimentacao);

                return true;
            }
        }

        public void DeleteMovimentacao(int id)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                connection.Execute(@"DELETE movimento WHERE IdContaCorrente = @IdContaCorrente", id);
            }
        }
    }
}
