using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models.Response
{
    public class PartClassAdditionalStatsConfigsResponse
    {
        [JsonProperty("list")] public List<PartClassAdditionalStatsConfigsModel> List;
    }
}