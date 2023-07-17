using Dapper;
using Microsoft.Data.Sqlite;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Sqlite;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace Questao5_Data.Infrastructure.Database.QueryStore.Requests
{
    public class ContaCorrenteQuery : IContaCorrenteQuery
    {
        private readonly DatabaseConfig _databaseConfig;

        public ContaCorrenteQuery(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<ContaCorrente>> GetAllContasCorrentesAsync()
        {

            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.OpenAsync();

                var query = @"
                                    SELECT MAX(m.idmovimento) AS idmovimento, c.idcontacorrente, c.numero, c.nome, c.ativo,
                                        CAST(SUM(CASE WHEN m.tipomovimento = 'C' THEN m.valor ELSE 0 END) AS REAL) AS Creditos,
                                        CAST(SUM(CASE WHEN m.tipomovimento = 'D' THEN m.valor ELSE 0 END) AS REAL) AS Debitos,
                                        m.datamovimento AS UltimaDataMovimentoString
                                    FROM contacorrente c
                                    LEFT JOIN movimento m ON c.idcontacorrente = m.idcontacorrente
                                    GROUP BY c.idcontacorrente, c.numero, c.nome, c.ativo";

                var queryResult = await connection.QueryAsync<ContaCorrente>(query);

                var lstContaCorrente = queryResult.Select(row => new ContaCorrente
                {
                    IdMovimento = row.IdMovimento,
                    IdContaCorrente = row.IdContaCorrente,
                    Numero = row.Numero,
                    Nome = row.Nome,
                    Ativo = row.Ativo,
                    Creditos = row.Creditos,
                    Debitos = row.Debitos,
                    Saldo = row.Creditos - row.Debitos,
                    UltimaDataMovimentoString = row.UltimaDataMovimentoString
                }).ToList();

                connection.Close();

                return lstContaCorrente;
            }
        }


        public async Task<IEnumerable<ContaCorrente>> GetAllContasCorrentes_SimplesAsync()
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<ContaCorrente>("SELECT * FROM contacorrente");
            }
        }


        public async Task<ContaCorrente> GetContaCorrenteAsync(int numeroConta)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.OpenAsync();

                // Consulta para obter as movimentações da conta
                var query = "SELECT * FROM movimento WHERE idcontacorrente = @NumeroConta";
                var movimentacoes = await connection.QueryAsync<Movimentacao>(query, new { NumeroConta = numeroConta });

                // Cálculo do saldo
                double saldo = movimentacoes.Where(m => m.TipoMovimento == 'C').Sum(m => m.Valor) -
                                movimentacoes.Where(m => m.TipoMovimento == 'D').Sum(m => m.Valor);

                // Consulta para obter os dados da conta corrente
                var queryContaCorrente = "SELECT * FROM contacorrente WHERE numero = @NumeroConta";
                var contaCorrente = await connection.QueryFirstOrDefaultAsync<ContaCorrente>(queryContaCorrente, new { NumeroConta = numeroConta });

                if (contaCorrente == null)
                {
                    // Conta corrente não encontrada
                    throw new Exception("Conta corrente não encontrada");
                }

                // Atribuir os valores calculados à conta corrente
                contaCorrente.UltimaDataMovimento = DateTime.Now;
                contaCorrente.Saldo = saldo;

                return contaCorrente;
            }
        }

        public async Task<ContaCorrente> GetContaCorrenteByIdAsync(string idContaCorrente)
        {
            using (var connection = new SqliteConnection(_databaseConfig.Name))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<ContaCorrente>("SELECT * FROM contacorrente WHERE IdContaCorrente = @IdContaCorrente",
                    new { IdContaCorrente = idContaCorrente });
            }
        }
    }
}
