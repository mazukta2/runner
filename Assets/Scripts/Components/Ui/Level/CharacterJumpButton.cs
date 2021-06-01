using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts.Components.Characters;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters;

namespace Assets.Scripts.Components.Ui.Level
{
    // Jump input for character.
    public class CharacterJumpButton : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] CharacterControlsProvider.Field _characterControlsProvider;

        private void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _characterControlsProvider.Get().Jump();
        }
    }
}

