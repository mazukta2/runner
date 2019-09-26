using UnityEngine;
using System.Collections;
using System.Linq;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicObject : MonoBehaviour
    {
        private const float GroundNormal = 1;

        public Vector2 Force { get => _force; set => _force = value; }
        public bool IsGrounded => _isGrounded;
        public PhysicSettingsData Settings { get => _Settings; set => _Settings = value; }

        [SerializeField] private PhysicSettingsData _Settings;
        [SerializeField] private ContactFilter2D _CollisionFilter;

        private Vector2 _force;
        private Collider2D _collider;
        private bool _isGrounded;

        protected void Start()
        {
            _collider = GetComponent<Collider2D>();
        }

        protected void Update()
        {
            if (!_Settings)
                return;

            // Gravitation. Adding G per second.
            _force += _Settings.Gravitation * Time.deltaTime;

            // Moving to position
            transform.Translate(_force * Time.deltaTime);

            // Collision calcultations
            _isGrounded = false;
            var hits = new Collider2D[6];
            int count = _collider.OverlapCollider(_CollisionFilter, hits);
            for (int i = 0; i < count; i++)
            {
                var hit = hits[i];
                var colliderDistance = hit.Distance(_collider);

                if (colliderDistance.isOverlapped)
                {
                    // Pushing backward
                    transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                    // Grounded if collider beneath
                    if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && _force.y < 0)
                    {
                        _isGrounded = true;

                        if (_force.y < 0) // Blocking falling
                            _force.y = 0;
                    }
                }
            }

            //if (_isGrounded)
            //{
            //    if (_force.y < 0) // Blocking falling
            //        _force.y = 0;
            //}
        }
    }
}
