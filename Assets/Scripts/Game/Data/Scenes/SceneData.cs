using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Common/Scene")]
    public class SceneData : ScriptableObject
    {
        public SceneLayerData Layer => _Layer;

        public string Path => _scenePath;

        [SerializeField] [Scene]
        public string _scenePath;

        [SerializeField] private SceneLayerData _Layer;
        [SerializeField] private SceneData[] _Requires;

        public Scene GetScene()
        {
            return SceneManager.GetSceneByName(_scenePath);
        }

        public void Init()
        {
            LoaderV2.AddToLoaded(this);

            LoaderV2.UnloadLayer(_Layer, this);
            foreach (var item in _Requires)
                LoaderV2.LoadScene(item);
        }

        public void Load()
        {
            LoaderV2.LoadScene(this);
        }

        public bool IsFullyLoaded()
        {
            if (!LoaderV2.IsLoaded(this))
                return false;

            foreach (var item in _Requires)
                if (!LoaderV2.IsLoaded(item))
                    return false;

            return true;
        }
    }

    public class SceneAttribute : PropertyAttribute
    {
    }
}
