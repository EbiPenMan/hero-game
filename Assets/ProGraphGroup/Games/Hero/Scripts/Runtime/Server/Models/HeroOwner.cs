using System;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroOwner
    {
                [JsonProperty("owner_id")] public string OwnerId;
                [JsonProperty("buy_time")] public DateTime BuyTime;
                [JsonProperty("sell_time")] public DateTime SellTime;
                [JsonProperty("exp")] public int Exp;
        
                public HeroOwner()
                {
                }
        
                public HeroOwner(string ownerId, DateTime buyTime, DateTime sellTime, int exp)
                {
                    OwnerId = ownerId;
                    BuyTime = buyTime;
                    SellTime = sellTime;
                    Exp = exp;
                }
    }
}