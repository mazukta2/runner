using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{

    public class MainMenuScreens : MonoBehaviour
    {
        [SerializeField] GameData _Game;
        [SerializeField] LoaderData _Loader;

        [SerializeField] Button _ToLevelSelectionButton;
        [SerializeField] Button _StartLevelButton;

        [SerializeField] Animator _Animator;
        [SerializeField] string _SelectionScreenAnimationTrigger;

        [SerializeField] CharacterSelector _CharacterSelector;
        [SerializeField] WorldSelector _WorldSelector;

        protected void Start()
        {
            _ToLevelSelectionButton.onClick.AddListener(ToLevelSelectionScreen);
            _StartLevelButton.onClick.AddListener(StartLevel);
        }

        protected void OnDestroy()
        {
            if (_ToLevelSelectionButton)
                _ToLevelSelectionButton.onClick.RemoveListener(ToLevelSelectionScreen);

            if (_StartLevelButton)
                _StartLevelButton.onClick.AddListener(StartLevel);
        }

        private void ToLevelSelectionScreen()
        {
            _Animator.SetTrigger(_SelectionScreenAnimationTrigger);
        }

        private void StartLevel()
        {
            _Game.Instance.World = _WorldSelector.CurrentElementData;
            _Game.Instance.Character = _CharacterSelector.CurrentElementData;

            _Loader.Instance.LoadLevel(_Game.Instance.World.Scene);
        }
    }
}