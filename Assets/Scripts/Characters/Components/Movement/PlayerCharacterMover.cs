using UnityEngine;
using System.Collections;

namespace Game
{
    [RequireComponent(typeof(PlayerCharacterController))]
    public class PlayerCharacterMover : MonoBehaviour
    {
        [SerializeField] public ContactFilter2D _CollisionFilter;
        [SerializeField] public LoaderData _Loader;

        private PlayerCharacterController _controller;

        private bool isColiided;

        private void Awake()
        {
            _controller = GetComponent<PlayerCharacterController>();
        }

        private void Update()
        {
            if (_controller == null)
                return;

            _controller.Character.Data.MovementRule.UpdatePosition(_controller.Character, Input.GetKey(KeyCode.Space));

            var collider = _controller.Character.GetComponent<Rigidbody2D>();
            var collisionCounts = collider.OverlapCollider(_CollisionFilter, new Collider2D[1]);

            if (collisionCounts > 0 && !isColiided)
            {
                isColiided = true;
                _Loader.Instance.LoadLevel(_Loader.FailScene);
            }
        }
    }
}
