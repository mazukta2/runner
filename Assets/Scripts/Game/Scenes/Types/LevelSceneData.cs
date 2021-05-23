using Assets.Scripts.Game.Data;
using Assets.Scripts.Game.Loader;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Game.Updater;
using Assets.Scripts.Session.PreSession;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Level")]
    public class LevelSceneData : SceneInfo
    {
        [SerializeField] DataService[] _dataServices;

        public override void PreInit(ServicesSystem servicesSystem)
        {
            foreach (var item in _dataServices)
                servicesSystem.Add(item);
        }

        public void Init(ServicesSystem servicesSystem, PreSessionService preSessionService)
        {
            servicesSystem.Add(new SessionService(preSessionService,
                servicesSystem.Get<GameLoadingService>(), 
                servicesSystem.Get<UpdaterService>()));
        }
    }
}
