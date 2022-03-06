using System;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class Hero
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("display_name")] public string DisplayName;
        [JsonProperty("class")] public HeroClassType Class;
        [JsonProperty("gene")] public string Gene;
        [JsonProperty("create_time")] public DateTime CreateTime;
        [JsonProperty("update_time")] public DateTime UpdateTime;

        public Hero()
        {
        }

        public Hero(string id, string displayName, HeroClassType @class, string gene, DateTime createTime, DateTime updateTime)
        {
            Id = id;
            DisplayName = displayName;
            Class = @class;
            Gene = gene;
            CreateTime = createTime;
            UpdateTime = updateTime;
        }
    }
}