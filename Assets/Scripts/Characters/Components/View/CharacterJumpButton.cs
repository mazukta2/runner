using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{
    public class CharacterJumpButton : MonoBehaviour
    {
        public PlayerCharacterMover Character { get => _Character; set => _Character = value; }

        [SerializeField] private Button _Button;
        [SerializeField] private PlayerCharacterMover _Character;

        private void Start()
        {
            _Button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            if (_Button)
                _Button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _Character.Jump();
        }
    }
}

