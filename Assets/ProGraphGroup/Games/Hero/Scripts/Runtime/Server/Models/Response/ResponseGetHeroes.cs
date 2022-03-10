using System.Collections.Generic;
using Newtonsoft.Json;
using ProGraphGroup.Games.Hero.Models;

namespace ProGraphGroup.Games.Hero.Server.Models.Response
{
    public class ResponseGetHeroes : BaseResponseModel
    {
        [JsonProperty("result")] public new ResponseGetHeroesResultModel Result;
    }

    public class ResponseGetHeroesResultModel
    {
        [JsonProperty("list")] public List<HeroModel> List;
    }
}