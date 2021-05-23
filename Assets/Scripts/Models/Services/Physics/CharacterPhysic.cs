using UnityEngine;
using System.Collections;
using System.Linq;
using Game;
using Assets.Scripts.Game.Updater;

namespace Assets.Scripts.Physics.Services
{
    public class CharacterPhysic
    {
        public Vector2 Position { get; set; }
        public Vector2 Force { get; set; }
        public bool IsGrounded { get; private set; }

        private PhysicSettingsData _settings;
        private BoxCollider2D _collider;

        public CharacterPhysic(PhysicSettingsData physicSettingsData, UpdaterService updaterSystem)
        {
            _settings = physicSettingsData;

            // TODO: make different prefab only for calculations 
            var go = new GameObject();
            GameObject.DontDestroyOnLoad(go);
            _collider = go.AddComponent<BoxCollider2D>();

            updaterSystem.AddUpdater(Update);
        }

        public bool IsCollidingWith(ContactFilter2D contactFilter2D)
        {
            var hits = new Collider2D[1];
            return _collider.OverlapCollider(contactFilter2D, hits) > 0;
        }

        protected void Update()
        {
            // Gravitation. Adding G per second.
            Force += _settings.Gravitation * Time.deltaTime;

            Position += Force * Time.deltaTime;

            // Collision calcultations
            IsGrounded = false;
            var hits = new Collider2D[6];
            int count = _collider.OverlapCollider(_settings.GroundCollisions, hits);
            for (int i = 0; i < count; i++)
            {
                var hit = hits[i];
                var colliderDistance = hit.Distance(_collider);

                if (colliderDistance.isOverlapped)
                {
                    // Pushing backward
                    Position += (colliderDistance.pointA - colliderDistance.pointB);

                    // Grounded if collider beneath
                    if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && Force.y < 0)
                    {
                        IsGrounded = true;

                        if (Force.y < 0) // Blocking falling
                            Force = new Vector2(Force.x, 0);
                    }
                }
            }
            _collider.transform.position = Position;
        }
    }
}
