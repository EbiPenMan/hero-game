using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using ProGraphGroup.Packages.Utility;
using Nakama;
using Newtonsoft.Json;
using ProGraphGroup.Games.Hero.Server;
using ProGraphGroup.Games.Hero.Server.Models;
using ProGraphGroup.Games.Hero.Server.Models.Response;
using ProGraphGroup.Games.Hero.UiManagers;
using ProGraphGroup.General.Utility;
using UnityEngine.Events;

namespace ProGraphGroup.Games.Hero.Managers
{
    public class HeroManager : MonoSingleton<HeroManager>
    {
        private Log _logger;

        public UnityEvent onSynceMyHeroes;

        private void Awake()
        {
            _logger = new Log("ServerManager");
        }

        public async UniTask<bool> GetMyHeroAsync()
        {
            onSynceMyHeroes?.Invoke();
            return transform;
        }
        
     
    }
}