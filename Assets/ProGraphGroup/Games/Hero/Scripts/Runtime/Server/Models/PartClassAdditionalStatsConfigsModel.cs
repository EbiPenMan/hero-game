using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class PartClassAdditionalStatsConfigsModel
    {
        [JsonProperty("type")]  public HeroClassType Type;
        [JsonProperty("stats")]  public HeroStats Stats;
    }
}