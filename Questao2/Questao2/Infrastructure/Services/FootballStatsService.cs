using System;
using System.Threading.Tasks;

namespace Questao2.Infrastructure.Services
{

    public class FootballStatsService
    {
        private readonly IFootballStatsApiClient footballStatsApiClient;

        public FootballStatsService(IFootballStatsApiClient footballStatsApiClient)
        {
            this.footballStatsApiClient = footballStatsApiClient;
        }

        public async Task<int> GetTotalScoredGoals(string team, int year)
        {
            int totalGoals = 0;
            int page = 1;
            bool hasNextPage = true;

            try
            {
                do
                {
                    var matches = await footballStatsApiClient.GetMatches(team, year, page);

                    if (matches != null)
                    {
                        foreach (var match in matches.Matches)
                        {
                            if (match.Team1 == team)
                            {
                                totalGoals += match.Team1Goals;
                            }
                            else if (match.Team2 == team)
                            {
                                totalGoals += match.Team2Goals;
                            }
                        }

                        page++;
                        hasNextPage = !string.IsNullOrEmpty(matches.NextPageUrl);
                    }
                    else
                    {
                        throw new MatchesRetrievalException("Não foi encontrado nenhum resultado");
                    }
                } while (hasNextPage);
            }
            catch (MatchesRetrievalException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return totalGoals;
        }
    }
}
