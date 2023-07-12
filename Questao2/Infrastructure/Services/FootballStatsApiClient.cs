using Newtonsoft.Json;
using Questao2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questao2.Infrastructure.Services
{
    public class FootballStatsApiClient
    {
        private readonly HttpClient httpClient;

        public FootballStatsApiClient()
        {
            httpClient = new HttpClient();
        }


        public async Task<FootballMatchesResponse> GetMatches(string team, int year, int page)
        {
            try
            {

                var allMatches = new List<FootballMatch>();
                bool hasNextPage = true;
                int totalPages = 0;

                do
                {
                    string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";

                    var response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var currentPageMatches = JsonConvert.DeserializeObject<FootballMatchesResponse>(result);
                        totalPages = currentPageMatches.TotalPages;

                        if (currentPageMatches != null)
                        {
                            allMatches.AddRange(currentPageMatches.Matches);
                        }
                    }
                    else
                    {
                        throw new MatchesRetrievalException("Erro ao buscar as partidas");
                    }

                    page++;
                } while (hasNextPage = page <= totalPages);

                var allMatchesResponse = new FootballMatchesResponse
                {
                    Matches = allMatches.ToArray(),
                    TotalPages = 0,
                    NextPageUrl = null
                };

                return allMatchesResponse;

            }
            catch (Exception ex)
            {
                throw new MatchesRetrievalException("Erro ao buscar as partidas");
            }
        }

    }
}
