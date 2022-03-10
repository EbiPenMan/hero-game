using System.Collections.Generic;
using Newtonsoft.Json;
using ProGraphGroup.General.Models;

namespace ProGraphGroup.Games.Hero.Models.Configs
{
    public class HeroClassListConfigs {
    
        [JsonProperty("list")]
        public IEnumerable<HeroClassConfigsModel> List;
    
    }
    
    public class HeroClassConfigsModel {
    
        [JsonProperty("type")]
        public HeroClassType Type;
    
        [JsonProperty("stats")]
        public HeroStats Stats;
    
        [JsonProperty("strongEffectTargetClasses")]
        public IEnumerable<HeroClassType> StrongEffectTargetClasses;
    
        [JsonProperty("weakEffectTargetClasses")]
        public IEnumerable<HeroClassType> WeakEffectTargetClasses;
    
        [JsonProperty("imageUrl")]
        public string ImageUrl;
    
        [JsonProperty("color")]
        public IEnumerable<SerializableColor> Color;
    
    }
}