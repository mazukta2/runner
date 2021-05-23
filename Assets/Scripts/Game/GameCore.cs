using Assets.Scripts.Game.Loader;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Game.Updater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
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
            _services = new ServicesSystem(this);
            _services.Add(new GameService(this));
            var loading = new GameLoadingService(this);
            _services.Add(loading);
            _services.Add(new UpdaterService(this));

            loading.LoadScene(_firstScene, (sr, sc) => { });
        }
    }
}
