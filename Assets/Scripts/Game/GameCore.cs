using Assets.Scripts.Game.Loader;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Game.Services;
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

        GameLoading _gameLoading;
        ServicesSystem _services;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _services = new ServicesSystem(this);
            _gameLoading = new GameLoading(this);

            _gameLoading.LoadScene(_firstScene);
        }

    }
}
