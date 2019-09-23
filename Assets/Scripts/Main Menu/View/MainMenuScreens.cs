using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{

    public class MainMenuScreens : MonoBehaviour
    {
        [SerializeField] Button _ToLevelSelectionButton;
        [SerializeField] Animator _Animator;
        [SerializeField] string _SelectionScreenAnimationTrigger;

        void Start()
        {
            _ToLevelSelectionButton.onClick.AddListener(ToLevelSelectionScreen);
        }

        private void OnDestroy()
        {
            if (_ToLevelSelectionButton)
                _ToLevelSelectionButton.onClick.RemoveListener(ToLevelSelectionScreen);
        }

        private void ToLevelSelectionScreen()
        {
            _Animator.SetTrigger(_SelectionScreenAnimationTrigger);
        }
    }
}