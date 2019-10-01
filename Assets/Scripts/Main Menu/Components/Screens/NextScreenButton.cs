using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{
    public class NextScreenButton : MonoBehaviour
    {
        [SerializeField] private Button _Button;
        [SerializeField] private Animator _Animator;
        [SerializeField] string _AnimationTrigger;

        void Start()
        {
            _Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _Animator.SetTrigger(_AnimationTrigger);
        }
    }

}
