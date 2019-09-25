using UnityEngine;
using System.Collections;
using System.Linq;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PhysicObject : MonoBehaviour
    {
        private const float GroundNormal = 1;

        [SerializeField] private PhysicSettingsData _Settings;
        [SerializeField] public ContactFilter2D _CollisionFilter;

        private Vector2 _force;
        private Rigidbody2D _rigidbody;
        private bool _isGrounded;

        protected void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected void Update()
        {
            var direction = (_force + _Settings.Gravitation) * Time.deltaTime;

            var hits = new RaycastHit2D[6];
            int count = _rigidbody.Cast(direction, _CollisionFilter,
                hits, direction.magnitude);

            for (int i = 0; i < hits.Length; i++)
            {
                Vector2 currentNormal = hits[i].normal;
                
                if (currentNormal.y > GroundNormal)
                    _isGrounded = true;

                var projection = Vector2.Dot(direction.normalized, currentNormal);
                if (projection < 0)
                {
                    direction = direction - projection * currentNormal;
                }
            }

            transform.position += (Vector3)direction;

        }

        public void AddForce(Vector2 force)
        {
            _force += force;

            if (_force.x > _Settings.MaximumForce.x)
                _force = new Vector2(_Settings.MaximumForce.x, _force.y);

            if (_force.y > _Settings.MaximumForce.y)
                _force = new Vector2(_force.x, _Settings.MaximumForce.y);
        }
    }
}
