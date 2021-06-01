using Assets.Scripts.Components.Core;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Characters;
using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Models.Services;
using UnityEngine;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Level")]
    public class LevelSceneData : SceneInfo
    {
        [SerializeField] DataService[] _dataServices;

        public void Init(ServicesSystem servicesSystem, PreSessionService preSessionService)
        {
            foreach (var item in _dataServices)
                servicesSystem.Add(item);

            servicesSystem.Add(new SessionService(preSessionService,
                servicesSystem.Get<CharactersSettingsData>(),
                servicesSystem.Get<GameLoadingService>()));
        }
    }
}
