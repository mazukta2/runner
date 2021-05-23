using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Models.Services.Game;
using Assets.Scripts.Models.Services.Scenes;
using Assets.Scripts.Models.Services.Updater;
using UnityEngine;

namespace Assets.Scripts.Components.Core
{
    // This is the enter point of the game.
    public class GameCore : MonoBehaviour
    {
        public ServicesSystem Services => _services;

        [SerializeField] SceneInfo _firstScene;

        ServicesSystem _services;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Init();
        }

        public void Restart()
        {
            Init();
        }

        private void Init()
        {
            _services = new ServicesSystem();

            _services.Add(new GameService(this));
            var loading = new GameLoadingService(this);
            _services.Add(loading);
            _services.Add(new UpdaterService(this));

            loading.LoadScene(_firstScene);
        }
    }
}
