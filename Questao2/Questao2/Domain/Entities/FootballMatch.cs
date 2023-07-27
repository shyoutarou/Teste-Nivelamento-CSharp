﻿using Newtonsoft.Json;

namespace Questao2.Domain.Entities
{
    public class FootballMatch
    {
        [JsonProperty("team1")]
        public string Team1 { get; set; }

        [JsonProperty("team2")]
        public string Team2 { get; set; }

        [JsonProperty("team1goals")]
        public int Team1Goals { get; set; }

        [JsonProperty("team2goals")]
        public int Team2Goals { get; set; }
    }
}
