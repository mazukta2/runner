using Assets.Scripts.Game.Data;
using Assets.Scripts.Game.Loader;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Session.PreSession;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Main Menu")]
    public class MainMenuSceneData : SceneInfo
    {
        [SerializeField] DataService[] _dataServices;

        public override void PreInit(ServicesSystem servicesSystem)
        {
            foreach (var item in _dataServices)
                servicesSystem.Add(item);

            servicesSystem.Add(new PreSessionService(servicesSystem.Get<GameLoadingService>()));
        }
    }
}
