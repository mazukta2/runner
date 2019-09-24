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

        void Start()
        {
            _ToLevelSelectionButton.onClick.AddListener(ToLevelSelectionScreen);
            _StartLevelButton.onClick.AddListener(StartLevel);
        }

        private void OnDestroy()
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
            _Game.Instance.Session = new Session(_WorldSelector.GetWorld(), _CharacterSelector.GetCharacter());

            _Loader.Instance.LoadLevel(_WorldSelector.GetWorld().Scene);
        }
    }
}