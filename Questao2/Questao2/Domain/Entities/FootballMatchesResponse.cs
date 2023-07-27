using Newtonsoft.Json;

namespace Questao2.Domain.Entities
{
    public class FootballMatchesResponse
    {
        [JsonProperty("data")]
        public FootballMatch[] Matches { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("next_page")]
        public string NextPageUrl { get; set; }
    }
}
