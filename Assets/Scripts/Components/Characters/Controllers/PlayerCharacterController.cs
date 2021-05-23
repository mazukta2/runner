using UnityEngine;
using System.Collections;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters.Services;

namespace Game
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] CharacterProvider.Field _characterProvider;

        private bool _jumpRequested;
        
        private void Update()
        {
            var character = _characterProvider.Get();

            character.Data.Movement.Move(character, _jumpRequested);

            _jumpRequested = false;
        }

        public void Jump()
        {
            _jumpRequested = true;
        }
    }
}
