using Assets.Scripts.Components.Core;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Models.Services;
using UnityEngine;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Main Menu")]
    public class MainMenuSceneData : SceneInfo
    {
        [SerializeField] DataService[] _dataServices;

        public void Init(ServicesSystem servicesSystem)
        {
            foreach (var item in _dataServices)
                servicesSystem.Add(item);

            servicesSystem.Add(new PreSessionService(servicesSystem.Get<GameLoadingService>()));
        }
    }
}
