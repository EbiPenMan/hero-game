using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroStats
    {
        [JsonProperty("health")] public int Health;
        [JsonProperty("speed")] public int Speed;
        [JsonProperty("skill")] public int Skill;
        [JsonProperty("morale")] public int Morale;
    }
}