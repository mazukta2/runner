using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Game
{
    public class StartLevelButton : MonoBehaviour
    {
        //[SerializeField] private SessionProvider _SessionProvider;
        [SerializeField] private Button _Button;

        void Start()
        {
            _Button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            //_SessionProvider.Instance.World.Scene.Load();
        }
    }

}
