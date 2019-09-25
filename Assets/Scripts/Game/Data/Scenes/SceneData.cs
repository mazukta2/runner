using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Common/Scene")]
    public class SceneData : ScriptableObject
    {
        public string Path => _scenePath;

        [SerializeField] [Scene]
        public string _scenePath;

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
