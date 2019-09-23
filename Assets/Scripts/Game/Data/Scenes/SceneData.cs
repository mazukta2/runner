using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Common/Scene")]
    public class SceneData : ScriptableObject
    {
        [SerializeField] [Scene]
        public string _scenePath;

        public AsyncOperation LoadAsync()
        {
            if (!SceneManager.GetSceneByName(_scenePath).isLoaded)
            {
                return SceneManager.LoadSceneAsync(_scenePath, LoadSceneMode.Additive);
            }
            return null;
        }

        internal bool IsScene(Scene otherScene)
        {
            var scene = SceneManager.GetSceneByName(_scenePath);
            return (otherScene == scene);
        }
    }

    public class SceneAttribute : PropertyAttribute
    {
    }
}
