using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models.Response
{
    public class HeroClassConfigsResponse
    {
        [JsonProperty("list")]  public List<HeroClassConfigsModel> List;
    }
}