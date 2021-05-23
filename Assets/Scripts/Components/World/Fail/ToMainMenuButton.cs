using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.MainMenu.Providers;
using Assets.Scripts.Game.Services;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class ToMainMenuButton : MonoBehaviour
    {
        [SerializeField] public GameProvider _gameProvider;

        private Button _button;
        private GameService _game;

        protected void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ToMainMenu);
            _game = _gameProvider.Get();
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(ToMainMenu);
        }

        private void ToMainMenu()
        {
            _game.Restart();
        }
    }

}
