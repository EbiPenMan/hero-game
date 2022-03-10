using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Models.Configs
{
    public class BuffDebuffListConfigs
    {
        [JsonProperty("list")] public IEnumerable<BuffDebuffConfigsModel> List;
    }

    public class BuffDebuffConfigsModel
    {
        [JsonProperty("type")] public BuffDebuffType Type;

        [JsonProperty("key")] public string Key;

        [JsonProperty("name")] public string Name;

        [JsonProperty("logicParams")] public object LogicParams;

        [JsonProperty("description")] public string Description;

        [JsonProperty("imageUrl")] public string ImageUrl;
    }

    public enum BuffDebuffType
    {
        Buff,
        Debuff
    }
}