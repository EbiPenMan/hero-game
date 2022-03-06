using System;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroChild
    {
        [JsonProperty("child_id")] public string ChildId;
        [JsonProperty("create_time")] public DateTime CreateTime;
        [JsonProperty("update_time")] public DateTime UpdateTime;

        public HeroChild()
        {
        }

        public HeroChild(string childId, DateTime createTime, DateTime updateTime)
        {
            ChildId = childId;
            CreateTime = createTime;
            UpdateTime = updateTime;
        }
    }
}