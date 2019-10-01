using UnityEngine;
using System.Collections;

namespace Game
{
    // Move character using commands from other classes 
    // and character movement rules.
    [RequireComponent(typeof(GameCharacterController))]
    public class CharacterMoveController : MonoBehaviour
    {
        private bool _jumpRequested;

        private void Start()
        {
            //_controller = GetComponent<GameCharacterController>();
        }

        private void Update()
        {
            //var data = _Provider.Character.Data;
            //data.MovementRule.Move(_Provider.Character, _jumpRequested);
            _jumpRequested = false;
        }

        public void Jump()
        {
            _jumpRequested = true;
        }
    }
}
