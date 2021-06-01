using Assets.Scripts.Components.Core;
using Assets.Scripts.Models.Services;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Data.Scenes
{
    // basic scene info
    public abstract class SceneInfo<TLoader> : ScriptableObject 
        where TLoader : LoaderBase
    {
        public string Path => _scenePath;
        [SerializeField] [Scene] private string _scenePath;

    }

    public abstract class LoaderBase
    {
        public abstract string Path { get; }

        public virtual void Load(GameCore core)
        {
            core.Services.Add(new GameService(core));
            core.Services.Add(new GameLoadingService(core));
            core.Services.Add(new UpdaterService(core));
        }
    }

    // editor attribute. so you can choose scene in assets.
    public class SceneAttribute : PropertyAttribute
    {
    }
}
