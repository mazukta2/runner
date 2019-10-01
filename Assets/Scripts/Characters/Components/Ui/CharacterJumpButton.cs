using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{
    public class CharacterJumpButton : MonoBehaviour
    {
        [SerializeField] private Button _Button;
        //[SerializeField] private PlayerControllerSceneProvider _ControllerProvider;

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
            //if (!_ControllerProvider.Controller)
            //    return;

            //_ControllerProvider.Controller.Mover.Jump();
        }
    }
}

