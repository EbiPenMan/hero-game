using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models.Response
{
    public class GetShopResponse: BaseResponseModel
    {
        [JsonProperty("result")] public new GetShopResponseResultModel Result;
    }

    public class GetShopResponseResultModel
    {
        [JsonProperty("list")] public List<HeroFullModel> List;
    }
}