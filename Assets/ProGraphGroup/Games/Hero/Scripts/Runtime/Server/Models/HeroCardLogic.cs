using System;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroCardLogic
    {
        [JsonProperty("id")] public string Id;
        [JsonProperty("description")] public string Description;
        [JsonProperty("image_url")] public string ImageUrl;
        [JsonProperty("create_time")] public DateTime CreateTime;
        [JsonProperty("update_time")] public DateTime UpdateTime;

        public HeroCardLogic()
        {
        }

        public HeroCardLogic(string id, string description, string imageUrl, DateTime createTime, DateTime updateTime)
        {
            Id = id;
            Description = description;
            ImageUrl = imageUrl;
            CreateTime = createTime;
            UpdateTime = updateTime;
        }
    }
}