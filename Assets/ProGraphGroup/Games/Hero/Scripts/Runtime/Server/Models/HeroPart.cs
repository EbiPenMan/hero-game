using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroPart
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("display_name")] public string DisplayName;
        [JsonProperty("source")] public string Source;
        [JsonProperty("type")] public string Type;
        [JsonProperty("classType")] public HeroClassType ClassType;
        [JsonProperty("move_type")] public string MoveType;
        [JsonProperty("image_url")] public string ImageUrl;
        [JsonProperty("create_time")] public DateTime CreateTime;
        [JsonProperty("update_time")] public DateTime UpdateTime;
        [JsonProperty("cards")] public List<HeroCard> Cards;

        public HeroPart()
        {
        }

        public HeroPart(string id, string displayName, string source, string type, HeroClassType classType, string moveType, string imageUrl, DateTime createTime, DateTime updateTime, List<HeroCard> cards)
        {
            Id = id;
            DisplayName = displayName;
            Source = source;
            Type = type;
            ClassType = classType;
            MoveType = moveType;
            ImageUrl = imageUrl;
            CreateTime = createTime;
            UpdateTime = updateTime;
            Cards = cards;
        }
    }
}