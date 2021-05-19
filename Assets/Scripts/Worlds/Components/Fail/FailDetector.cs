using UnityEngine;
using System.Collections;
using Assets.Scripts.Game.Scenes;

namespace Game
{
    public class FailDetector : MonoBehaviour
    {
        [SerializeField] private SceneInfo _FailScene;
        [SerializeField] private CharacterControllerProvider _CharacterProvider;

        private bool isCollided;

        protected void Update()
        {
            if (!_CharacterProvider.Controller)
                return;

            var hitBox = _CharacterProvider.Controller.Model.Hitable;
            if (hitBox.IsCollideWithDanger() && !isCollided)
            {
                isCollided = true;
                //_FailScene.Load();
            }
        }
    }
}

