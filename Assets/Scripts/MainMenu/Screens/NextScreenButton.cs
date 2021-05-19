using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.MainMenu.Screens
{
    public class NextScreenButton : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] Animator _animator;
        [SerializeField] string _animationTrigger;

        void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            _animator.SetTrigger(_animationTrigger);
        }
    }

}
