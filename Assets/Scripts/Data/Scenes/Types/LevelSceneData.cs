using Assets.Scripts.Components.Core;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Characters;
using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Models.Services;
using UnityEngine;
using static Assets.Scripts.Game.Scenes.Types.LevelSceneData;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Level")]
    public class LevelSceneData : SceneInfo<Loader>
    {
        [SerializeField] DataService[] _dataServices;

        public class Loader : LoaderBase
        {
            public override string Path => _scene.Path;
            private LevelSceneData _scene;
            private PreSessionService _preSessionService;

            public Loader(LevelSceneData sceneData, PreSessionService preSessionService)
            {
                _scene = sceneData;
                _preSessionService = preSessionService;
            }

            public override void Load(GameCore core)
            {
                base.Load(core);

                foreach (var item in _scene._dataServices)
                    core.Services.Add(item);

                var updater = core.Services.Get<UpdaterService>();
                var charSettings = core.Services.Get<CharactersSettingsData>();
                var session = new SessionService(_preSessionService,
                    charSettings,
                    core.Services.Get<GameLoadingService>());

                core.Services.Add(session);
                var physics = new CharacterPhysicsService(_preSessionService.SelectedWorldData.Physics, updater);
                core.Services.Add(physics);
                core.Services.Add(new CharacterControlsService(session.MainCharacter, updater));
                core.Services.Add(new FailDetectorService(session, physics, charSettings, updater));
            }
        }
    }
}
