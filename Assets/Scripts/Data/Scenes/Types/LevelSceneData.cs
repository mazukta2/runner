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

            var updater = servicesSystem.Get<UpdaterService>();
            var charSettings = servicesSystem.Get<CharactersSettingsData>();
            var session = new SessionService(preSessionService,
                charSettings,
                servicesSystem.Get<GameLoadingService>());

            servicesSystem.Add(session);
            var physics = new CharacterPhysicsService(preSessionService.SelectedWorldData.Physics, updater);
            servicesSystem.Add(physics);
            servicesSystem.Add(new CharacterControlsService(session.MainCharacter, updater));
            servicesSystem.Add(new FailDetectorService(session, physics, charSettings, updater));
        }
    }
}
