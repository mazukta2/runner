using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.Scripts.Components.Characters;
using Assets.Scripts.Characters.Settings;

namespace Assets.Scripts.Components.Ui.Level
{
    // Jump input for character.
    public class CharacterJumpButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] CharacterProvider.Field _characterProvider;

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
            // TODO: In more complex game you should make another class
            // to accumulate all input from UI/Keyboard/Gamepad/etc and
            // manage it.
            //_characterProvider.Get().World.Jump();
        }
    }
}

