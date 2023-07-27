using Questao2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2.Infrastructure.Services
{
    public interface IFootballStatsApiClient
    {
        Task<FootballMatchesResponse> GetMatches(string team, int year, int page);
    }
}
