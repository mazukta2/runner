using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public class SceneInit : MonoBehaviour
    {
        public bool IsFullyLoaded => _CurrentScene.IsFullyLoaded();
        public event EventHandler OnLoaded = delegate { };

        [SerializeField] private SceneData _CurrentScene;
        private bool _isLoaded;

        protected void Awake()
        {
            _CurrentScene.Init();

            TryToFireOnLoded();
        }

        protected void Update()
        {
            TryToFireOnLoded();
        }

        private void TryToFireOnLoded()
        {
            if (_isLoaded)
                return;

            if (!IsFullyLoaded)
                return;

            _isLoaded = true;

            OnLoaded(this, EventArgs.Empty);
        }
    }
}
