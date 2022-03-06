using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroCard
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("display_name")] public string DisplayName;
        [JsonProperty("energy")] public int Energy;
        [JsonProperty("attack")] public int Attack;
        [JsonProperty("defence")] public int Defence;
        [JsonProperty("image_url")] public string ImageUrl;
        [JsonProperty("create_time")] public DateTime CreateTime;
        [JsonProperty("update_time")] public DateTime UpdateTime;
        [JsonProperty("logics")] public List<HeroCardLogic> Logics;

        public HeroCard()
        {
        }

        public HeroCard(string id, string displayName, int energy, int attack, int defence, string imageUrl, DateTime createTime, DateTime updateTime, List<HeroCardLogic> logics)
        {
            Id = id;
            DisplayName = displayName;
            Energy = energy;
            Attack = attack;
            Defence = defence;
            ImageUrl = imageUrl;
            CreateTime = createTime;
            UpdateTime = updateTime;
            Logics = logics;
        }
    }
}