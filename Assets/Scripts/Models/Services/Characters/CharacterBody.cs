using UnityEngine;
using Assets.Scripts.Data.Physics;
using Assets.Scripts.Data.Characters;
using Assets.Scripts.Models.Services.Updater;

namespace Assets.Scripts.Models.Services.Characters
{
    public class CharacterBody
    {
        public Vector2 Position { get; set; }
        public Vector2 Force { get; set; }
        public bool IsGrounded { get; private set; }
        // 
        private PhysicSettingsData _settings;
        private BoxCollider2D _collider;
        private CharactersSettingsData _charactersSettings;
        private bool _jumpRequest;

        public CharacterBody(PhysicSettingsData physicSettingsData,
            CharactersSettingsData charactersSettings, UpdaterService updaterSystem)
        {
            _settings = physicSettingsData;

            // TODO: make different prefab only for calculations 
            var go = new GameObject();
            Object.DontDestroyOnLoad(go);
            _collider = go.AddComponent<BoxCollider2D>();

            updaterSystem.AddUpdater(Update);
            _charactersSettings = charactersSettings;
        }

        public bool IsCollidingWith(ContactFilter2D contactFilter2D)
        {
            var hits = new Collider2D[1];
            return _collider.OverlapCollider(contactFilter2D, hits) > 0;
        }

        public bool IsCollidingWithDanger()
        {
            return IsCollidingWith(_charactersSettings.DangerCollision);
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
                    Position += colliderDistance.pointA - colliderDistance.pointB;

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
            _jumpRequest = false;
        }

        public void Jump()
        {
            _jumpRequest = true;
        }

    }
}
