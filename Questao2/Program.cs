using Questao2.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace Questao2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                FootballStatsService footballStatsService = new FootballStatsService();

                Console.WriteLine("=== Gols de um time por ano (Digite S para sair) ===");
                Console.WriteLine();

                while (true)
                {
                    Console.Write("Digite o nome do time: ");
                    string teamName = Console.ReadLine();

                    if (teamName.ToUpper() == "S") break;

                    Console.Write("Digite o ano: ");
                    string year = Console.ReadLine();

                    if (year.ToUpper() == "S")  break;

                    int totalGoals = await footballStatsService.GetTotalScoredGoals(teamName, Convert.ToInt32(year));
                    Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);
                    Console.WriteLine("====================================================");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
