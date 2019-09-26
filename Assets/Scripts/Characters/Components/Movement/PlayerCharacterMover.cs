using UnityEngine;
using System.Collections;

namespace Game
{
    [RequireComponent(typeof(PlayerCharacterController))]
    public class PlayerCharacterMover : MonoBehaviour
    {
        private PlayerCharacterController _controller;
        private bool _jump;

        private void Awake()
        {
            _controller = GetComponent<PlayerCharacterController>();
        }

        private void Update()
        {
            if (_controller == null)
                return;

            _controller.Character.Data.MovementRule.UpdatePosition(_controller.Character, _jump || Input.GetKey(KeyCode.Space));

            _jump = false;
        }

        public void Jump()
        {
            _jump = true;
        }
    }
}
