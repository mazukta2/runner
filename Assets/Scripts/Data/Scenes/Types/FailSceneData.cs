using Assets.Scripts.Components.Core;
using Assets.Scripts.Data.Scenes;
using UnityEngine;
using static Assets.Scripts.Game.Scenes.Types.FailSceneData;

namespace Assets.Scripts.Game.Scenes.Types
{
    [CreateAssetMenu(menuName = "Game/Scenes/Fail")]
    public class FailSceneData : SceneInfo<Loader>
    {
        public class Loader : LoaderBase
        {
            public override string Path => _scene.Path;
            private FailSceneData _scene;

            public Loader(FailSceneData sceneData)
            {
                _scene = sceneData;
            }
        }
    }
}
