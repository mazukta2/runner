using UnityEngine;
using System.Collections;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters.Services;

namespace Game
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] CharacterProvider _characterProvider;

        private bool _jumpRequested;
        private Character _character;

        protected void Awake()
        {
            _character = _characterProvider.Get();
        }

        private void Update()
        {
            _character.Data.Movement.Move(_character, _jumpRequested);
            _jumpRequested = false;
        }

        public void Jump()
        {
            _jumpRequested = true;
        }
    }
}
