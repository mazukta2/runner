using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Components.Providers.Common;

namespace Assets.Scripts.Components.Ui.Fail
{
    // from fail screen to main menu
    [RequireComponent(typeof(Button))]
    public class ToMainMenuButton : MonoBehaviour
    {
        [SerializeField] public GameProvider.Field _gameProvider;

        private Button _button;

        protected void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ToMainMenu);
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(ToMainMenu);
        }

        private void ToMainMenu()
        {
            _gameProvider.Get().Restart();
        }
    }

}
