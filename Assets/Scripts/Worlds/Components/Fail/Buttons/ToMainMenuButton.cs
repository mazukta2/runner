using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using Assets.Scripts.Game.Scenes;

namespace Game
{
    [RequireComponent(typeof(Button))]
    public class ToMainMenuButton : MonoBehaviour
    {
        [SerializeField] public SceneInfo _MainMenu;

        private Button _button;

        protected void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ToMainMenu);
        }

        protected void OnDestroy()
        {
            if (_button)
                _button.onClick.RemoveListener(ToMainMenu);
        }

        private void ToMainMenu()
        {
            //_MainMenu.Load();
        }
    }

}
