using Assets.Scripts.Components.Core;
using Assets.Scripts.Data;
using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Models.Services;
using UnityEngine;
using static Assets.Scripts.Game.Scenes.Types.MainMenuSceneData;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Main Menu")]
    public class MainMenuSceneData : SceneInfo<Loader>
    {
        [SerializeField] DataService[] _dataServices;

        public class Loader : LoaderBase
        {
            public override string Path => _scene.Path;
            private MainMenuSceneData _scene;

            public Loader(MainMenuSceneData sceneData)
            {
                _scene = sceneData;
            }

            public override void Load(GameCore core)
            {
                base.Load(core);

                foreach (var item in _scene._dataServices)
                    core.Services.Add(item);

                core.Services.Add(new PreSessionService(core.Services.Get<GameLoadingService>()));
            }
        }
    }
}
