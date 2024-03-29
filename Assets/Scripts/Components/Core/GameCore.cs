﻿using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Game.Scenes.Types;
using Assets.Scripts.Models.Services;
using UnityEngine;

namespace Assets.Scripts.Components.Core
{
    // This is the enter point of the game.
    public class GameCore : MonoBehaviour
    {
        public ServicesSystem Services => _services;

        [SerializeField] MainMenuSceneData _firstScene;

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

            var loading = new GameLoadingService(this);
            _services.Add(loading);

            loading.LoadScene(new MainMenuSceneData.Loader(_firstScene));
        }
    }
}
