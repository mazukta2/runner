using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{
    public class CharacterJumpButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PlayerCharacterController _playerCharacterController;

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
            _playerCharacterController.Jump();
        }
    }
}

