using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Models.Configs
{
    public class PartClassAdditionalStatsListConfigs {
    
        [JsonProperty("list")]
        public IEnumerable<PartClassAdditionalStatsConfigsModel> List;
    
    }
    
    public class PartClassAdditionalStatsConfigsModel {
    
        [JsonProperty("type")]
        public HeroClassType Type;
    
        [JsonProperty("stats")]
        public HeroStats Stats;
    
    }
}