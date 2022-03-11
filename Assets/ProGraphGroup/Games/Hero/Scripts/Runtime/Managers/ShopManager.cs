using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ProGraphGroup.Packages.Utility;
using Nakama.TinyJson;
using Newtonsoft.Json;
using ProGraphGroup.Games.Hero.Models;
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
        private Dictionary<string, HeroModel> heroMap = new Dictionary<string, HeroModel>();

        private void Awake()
        {
            _logger = new Log("ShopManager");
        }

        void Start()
        {
        }

        public async UniTask GetShop(int pageNumber)
        {
            // SelectQueryInputModel inputModel = new SelectQueryInputModel();
            // inputModel.Limit = 2;
            // inputModel.Offset = pageNumber;
            //
            // GetShopResponse res = await ServerManager.Instance.GetShopItems(inputModel);
            // foreach (HeroFullModel heroFullModel in res.Result.List)
            // {
            //     heroFullMap.Add(heroFullModel.Hero.Id, heroFullModel);
            // }
            //
            await GetMyHeroes();
        }

        public async UniTask GetMyHeroes()
        {
            ResponseGetHeroes res2 = await ServerManager.Instance.GetMyHero();
            foreach (HeroModel heroModel in res2.Result.List)
            {
                heroMap.Add(heroModel.Id, heroModel);
            }
        }
    }
}