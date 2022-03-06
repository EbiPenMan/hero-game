using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProGraphGroup.Games.Hero.Server.Models
{
    public class HeroFullModel
    {
        [JsonProperty("axie")] public Hero Hero;
        [JsonProperty("owners")] public List<HeroOwner> Owners;
        [JsonProperty("children")] public List<HeroChild> Children;
        [JsonProperty("parts")] public List<HeroPart> Parts;

        public HeroFullModel()
        {
        }

        public HeroFullModel(Hero axie, List<HeroOwner> owners, List<HeroChild> children, List<HeroPart> parts)
        {
            Hero = axie;
            Owners = owners;
            Children = children;
            Parts = parts;
        }
    }
}