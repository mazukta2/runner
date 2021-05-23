using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.Components.Ui.MainMenu
{
    // Switch screen in main menu
    public class NextScreenButton : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] Animator _animator;
        [SerializeField] string _animationTrigger;

        protected void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        void OnClick()
        {
            _animator.SetTrigger(_animationTrigger);
        }
    }

}
