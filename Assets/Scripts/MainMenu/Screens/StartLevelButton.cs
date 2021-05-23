using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts.MainMenu.Providers;
using Assets.Scripts.Session.PreSession;

namespace Game
{
    public class StartLevelButton : MonoBehaviour
    {
        [SerializeField] private PreSessionProvider _preSessionProvider;
        [SerializeField] private Button _button;
        private PreSessionService _preSession;

        protected void Awake()
        {
            _button.onClick.AddListener(OnClick);
            _preSession = _preSessionProvider.Get();
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _preSession.StartSession();
        }
    }

}
