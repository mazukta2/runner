using Assets.Scripts.Game.Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Scenes
{
    public abstract class SceneInfo : ScriptableObject
    {
        public string Path => _scenePath;
        [SerializeField] [Scene] private string _scenePath;
        public abstract void PreInit(ServicesSystem servicesSystem);
    }

    // editor attribute. so you can choose scene in assets.
    public class SceneAttribute : PropertyAttribute 
    {
    }
}
