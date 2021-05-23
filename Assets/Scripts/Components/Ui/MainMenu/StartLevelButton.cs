using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Components.Providers.Sessions;

namespace Assets.Scripts.Components.Ui.MainMenu
{
    public class StartLevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PreSessionProvider.Field _preSessionProvider;

        protected void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _preSessionProvider.Get().StartSession();
        }
    }

}
