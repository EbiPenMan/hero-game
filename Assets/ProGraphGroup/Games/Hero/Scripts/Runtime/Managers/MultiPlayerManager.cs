using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ProGraphGroup.Packages.Utility;
using Nakama.TinyJson;
using Newtonsoft.Json;
using ProGraphGroup.Games.Hero.Server;
using ProGraphGroup.Games.Hero.Server.Models;
using ProGraphGroup.Games.Hero.Server.Models.Response;
using ProGraphGroup.General.Utility;
using UnityEngine;

namespace ProGraphGroup.Games.Hero
{
    public class ShopManager : MonoSingleton<ShopManager>
    {
        private Log _logger;
        private Dictionary<string, HeroFullModel> heroFullMap = new Dictionary<string, HeroFullModel>();

        private void Awake()
        {
            _logger = new Log("ShopManager");
        }

        void Start()
        {
        }

        public async UniTask GetShop(int pageNumber)
        {
            SelectQueryInputModel inputModel = new SelectQueryInputModel();
            inputModel.Limit = 2;
            inputModel.Offset = pageNumber;

            GetShopResponse res = await ServerManager.Instance.GetShopItems(inputModel);
            foreach (HeroFullModel heroFullModel in res.Result.List)
            {
                heroFullMap.Add(heroFullModel.Hero.Id, heroFullModel);
            }

            await GetMyHeroes();
        }

        public async UniTask GetMyHeroes()
        {
            // GetShopResponse res2 = await ServerManager.Instance.GetMyHero();
            // foreach (HeroFullModel heroFullModel in res2.Result.List)
            // {
            //     heroFullMap.Add(heroFullModel.Hero.Id, heroFullModel);
            // }
        }
    }
}