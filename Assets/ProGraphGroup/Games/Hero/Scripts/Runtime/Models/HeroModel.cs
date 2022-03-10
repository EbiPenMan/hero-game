using UnityEngine;

namespace ProGraphGroup.Games.Hero.Models
{
    public class HeroModel
    {
        [Newtonsoft.Json.JsonProperty("birth_date")]
        public System.DateTime BirthDate;

        [Newtonsoft.Json.JsonProperty("breed_history")]
        public HeroBreedModel[] BreedHistory;

        [Newtonsoft.Json.JsonProperty("class_type")]
        public HeroClassType ClassType;

        [Newtonsoft.Json.JsonProperty("current_owner_id")]
        public string CurrentOwnerId;

        [Newtonsoft.Json.JsonProperty("current_sale")]
        public HeroSaleModel CurrentSale;

        [Newtonsoft.Json.JsonProperty("genes")]
        public HeroGeneModel[] Genes;

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id;

        [Newtonsoft.Json.JsonProperty("name_hero")]
        public string NameHero;

        [Newtonsoft.Json.JsonProperty("number_id")]
        public double NumberId;

        [Newtonsoft.Json.JsonProperty("parents_id")]
        public string[] ParentsId;

        [Newtonsoft.Json.JsonProperty("parts")]
        public HeroPartModel[] Parts;

        [Newtonsoft.Json.JsonProperty("sale_history")]
        public HeroSaleModel[] SaleHistory;

        [Newtonsoft.Json.JsonProperty("source_hero")]
        public HeroSourceType SourceHero;

        [Newtonsoft.Json.JsonProperty("stage")]
        public HeroStageType Stage;

        [Newtonsoft.Json.JsonProperty("stats")]
        public HeroStats Stats;

        [Newtonsoft.Json.JsonProperty("updated_at")]
        public System.DateTime UpdatedAt;

        [Newtonsoft.Json.JsonProperty("xp")]
        public double Xp;
    }

    public class HeroAbilityLogicModel
    {

        [Newtonsoft.Json.JsonProperty("created_at")]
        public System.DateTime CreatedAt;

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description;

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id;

        [Newtonsoft.Json.JsonProperty("image_url")]
        public string ImageUrl;

        [Newtonsoft.Json.JsonProperty("updated_at")]
        public System.DateTime UpdatedAt;
    }

    public class HeroAbilityModel
    {

        [Newtonsoft.Json.JsonProperty("attack")]
        public double Attack;

        [Newtonsoft.Json.JsonProperty("created_at")]
        public System.DateTime CreatedAt;

        [Newtonsoft.Json.JsonProperty("defence")]
        public double Defence;

        [Newtonsoft.Json.JsonProperty("display_name")]
        public string DisplayName;

        [Newtonsoft.Json.JsonProperty("energy")]
        public double Energy;

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id;

        [Newtonsoft.Json.JsonProperty("image_url")]
        public string ImageUrl;

        [Newtonsoft.Json.JsonProperty("logic")]
        public HeroAbilityLogicModel Logic;

        [Newtonsoft.Json.JsonProperty("logic_id")]
        public string LogicId;

        [Newtonsoft.Json.JsonProperty("updated_at")]
        public System.DateTime UpdatedAt;
    }

    public class HeroBreedCostModel
    {

        [Newtonsoft.Json.JsonProperty("amount")]
        public double Amount;

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency;
    }

    public class HeroBreedModel
    {

        [Newtonsoft.Json.JsonProperty("child_id")]
        public string ChildId;

        [Newtonsoft.Json.JsonProperty("cost")]
        public HeroBreedCostModel[] Cost;

        [Newtonsoft.Json.JsonProperty("parent_id")]
        public string ParentId;

        [Newtonsoft.Json.JsonProperty("start_at")]
        public System.DateTime StartAt;
    }

    public class HeroGeneModel
    {

        [Newtonsoft.Json.JsonProperty("back")]
        public HeroGenePartModel Back;

        [Newtonsoft.Json.JsonProperty("color")]
        public Color Color;

        [Newtonsoft.Json.JsonProperty("ear")]
        public HeroGenePartModel Ear;

        [Newtonsoft.Json.JsonProperty("eye")]
        public HeroGenePartModel Eye;

        [Newtonsoft.Json.JsonProperty("horn")]
        public HeroGenePartModel Horn;

        [Newtonsoft.Json.JsonProperty("mouth")]
        public HeroGenePartModel Mouth;

        [Newtonsoft.Json.JsonProperty("pattern")]
        public HeroPartPatternType Pattern;

        [Newtonsoft.Json.JsonProperty("tail")]
        public HeroGenePartModel Tail;
    }

    public class HeroGenePartModel
    {

        [Newtonsoft.Json.JsonProperty("class_type")]
        public HeroClassType ClassType;

        [Newtonsoft.Json.JsonProperty("part_id")]
        public string PartId;

        [Newtonsoft.Json.JsonProperty("special_type")]
        public HeroPartSpecialType SpecialType;
    }


    public class HeroPartModel
    {

        [Newtonsoft.Json.JsonProperty("ability")]
        public HeroAbilityModel Ability;

        [Newtonsoft.Json.JsonProperty("ability_id")]
        public string AbilityId;

        [Newtonsoft.Json.JsonProperty("class_type")]
        public HeroClassType ClassType;

        [Newtonsoft.Json.JsonProperty("created_at")]
        public System.DateTime CreatedAt;

        [Newtonsoft.Json.JsonProperty("display_name")]
        public string DisplayName;

        [Newtonsoft.Json.JsonProperty("id")]
        public string Id;

        [Newtonsoft.Json.JsonProperty("special_type_data",
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecialTypeDataModel SpecialTypeData;

        [Newtonsoft.Json.JsonProperty("updated_at")]
        public System.DateTime UpdatedAt;
    }

    public class HeroQueryModel
    {

        [Newtonsoft.Json.JsonProperty("breedCountRange")]
        public HeroQueryRangeModel BreedCountRange;

        [Newtonsoft.Json.JsonProperty("class_type")]
        public HeroClassType[] ClassType;

        [Newtonsoft.Json.JsonProperty("forNotSale")]
        public bool ForNotSale;

        [Newtonsoft.Json.JsonProperty("forSale")]
        public bool ForSale;

        [Newtonsoft.Json.JsonProperty("lastPageKeyValue")]
        public string LastPageKeyValue;

        [Newtonsoft.Json.JsonProperty("limit")]
        public double Limit;

        [Newtonsoft.Json.JsonProperty("partIds")]
        public string[] PartIds;

        [Newtonsoft.Json.JsonProperty("partSpecialTypeList",
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HeroQueryPartSpecialType[] PartSpecialTypeList;

        [Newtonsoft.Json.JsonProperty("purityGeneticsPercentRange",
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HeroQueryRangeModel PurityGeneticsPercentRange;

        [Newtonsoft.Json.JsonProperty("purityPartsNumber",
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double PurityPartsNumber;

        [Newtonsoft.Json.JsonProperty("sortType")]
        public HeroQuerySortType SortType;

        [Newtonsoft.Json.JsonProperty("sourceTypeList")]
        public HeroSourceType[] SourceTypeList;

        [Newtonsoft.Json.JsonProperty("stage")]
        public HeroStageType[] Stage;

        [Newtonsoft.Json.JsonProperty("statsRange")]
        public HeroQueryStatsRange[] StatsRange;
    }

    public class HeroQueryPartSpecialType
    {

        [Newtonsoft.Json.JsonProperty("numberOfParts")]
        public double NumberOfParts;

        [Newtonsoft.Json.JsonProperty("partSpecialType")]
        public HeroPartSpecialType PartSpecialType;
    }

    public class HeroQueryRangeModel
    {
        public HeroQueryRangeModel(double minValue, double maxValue) => throw new System.NotImplementedException();

        [Newtonsoft.Json.JsonProperty("maxValue")]
        public double MaxValue;

        [Newtonsoft.Json.JsonProperty("minValue")]
        public double MinValue;
    }

    public class HeroQueryStatsRange
    {

        [Newtonsoft.Json.JsonProperty("range")]
        public HeroQueryRangeModel Range;

        [Newtonsoft.Json.JsonProperty("statsRangeType")]
        public HeroQueryStatsRangeType StatsRangeType;
    }

    public class HeroSaleModel
    {

        [Newtonsoft.Json.JsonProperty("buy_at")]
        public System.DateTime BuyAt;

        [Newtonsoft.Json.JsonProperty("buyer_id")]
        public string BuyerId;

        [Newtonsoft.Json.JsonProperty("end_sale")]
        public System.DateTime EndSale;

        [Newtonsoft.Json.JsonProperty("end_sale_price")]
        public double EndSalePrice;

        [Newtonsoft.Json.JsonProperty("sale_price")]
        public double SalePrice;

        [Newtonsoft.Json.JsonProperty("seller_id")]
        public string SellerId;

        [Newtonsoft.Json.JsonProperty("start_sale")]
        public System.DateTime StartSale;

        [Newtonsoft.Json.JsonProperty("start_sale_price")]
        public double StartSalePrice;

        [Newtonsoft.Json.JsonProperty("xp")]
        public double Xp;
    }

    public class HeroStats
    {

        [Newtonsoft.Json.JsonProperty("health")]
        public double Health;

        [Newtonsoft.Json.JsonProperty("morale")]
        public double Morale;

        [Newtonsoft.Json.JsonProperty("skill")]
        public double Skill;

        [Newtonsoft.Json.JsonProperty("speed")]
        public double Speed;
    }

//     public class Color
//     {
//         public Color(double r, double g, double b, double a) => throw new System.NotImplementedException();
//
//         [Newtonsoft.Json.JsonProperty("a")]
//         public double A; = 0;
//
//         [Newtonsoft.Json.JsonProperty("b")]
//         public double B; = 0;
//
//         [Newtonsoft.Json.JsonProperty("g")]
//         public double G; = 0;
//
//         [Newtonsoft.Json.JsonProperty("r")]
//         public double R; = 0;
//
// }

    public class SpecialTypeDataModel
    {

        [Newtonsoft.Json.JsonProperty("image_url")]
        public string ImageUrl;

        [Newtonsoft.Json.JsonProperty("position")]
        public string Position;

        [Newtonsoft.Json.JsonProperty("special_type")]
        public HeroPartSpecialType SpecialType;
    }

    public enum HeroPartPatternType
    {
        None,
        p1,
        p2,
        p3
    }

    public enum HeroPartSpecialType
    {
        None,
        Mystic,
        Japanese,
        Christmas
    }

    public enum HeroSourceType
    {
        None,
        Origin,
        MEO,
        MEOII
    }

    public enum HeroStageType
    {
        None,
        Egg,
        Adult
    }

    public enum HeroClassType
    {
        None,
        Aquatic,
        Bird,
        Reptile,
        Beast,
        Bug,
        Plant,
        Mech,
        Dawn,
        Dusk,
    }

    public enum HeroQueryStatsRangeType
    {
        None,
        Health,
        Speed,
        Skill,
        Morale
    }

    public enum HeroQuerySortType
    {
        None,
        LowestId,
        HighestId,
        LowestPrice,
        HighestPrice,
        Latest,
    }
}