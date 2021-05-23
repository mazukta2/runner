using UnityEngine;
using System.Collections;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters.Services;
using Assets.Scripts.MainMenu.Providers;
using Assets.Scripts.Session.PreSession;

namespace Game
{
    public class FailDetector : MonoBehaviour
    {
        [SerializeField] private SessionProvider _sessionProvider;
        [SerializeField] private CharacterProvider _characterProvider;

        private bool isCollided;
        private Character _character;
        private SessionService _session;

        protected void Awake()
        {
            _character = _characterProvider.Get();
            _session = _sessionProvider.Get();
        }

        protected void Update()
        {
            if (_character.Hitable.IsCollidingWithDanger() && !isCollided)
            {
                isCollided = true;
                _session.FailSession();
            }
        }
    }
}

