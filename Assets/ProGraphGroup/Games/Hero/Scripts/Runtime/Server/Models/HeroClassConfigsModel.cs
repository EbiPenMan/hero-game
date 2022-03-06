using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ProGraphGroup.General.Models;
using UnityEngine;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    [Serializable]
    public class HeroClassConfigsModel
    {
        [JsonProperty("type")] public HeroClassType Type;
        [JsonProperty("stats")] public HeroStats Stats;

        [JsonProperty("strong_effect_target_classes")]
        public List<HeroClassType> StrongEffectTargetClasses = new List<HeroClassType>();

        [JsonProperty("weak_effect_target_classes")]
        public List<HeroClassType> WeakEffectTargetClasses = new List<HeroClassType>();

        [JsonProperty("image_url")] public string ImageUrl;
        [JsonProperty("color")] public List<SerializableColor> Colors = new List<SerializableColor>();

   
    }
}