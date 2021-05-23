using Assets.Scripts.Components.Core;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Data.Scenes
{
    // basic scene info
    public abstract class SceneInfo : ScriptableObject
    {
        public string Path => _scenePath;
        [SerializeField] [Scene] private string _scenePath;
    }

    // editor attribute. so you can choose scene in assets.
    public class SceneAttribute : PropertyAttribute
    {
    }
}
