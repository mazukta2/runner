using Assets.Scripts.Components.Characters;
using Assets.Scripts.Data.Physics;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Services
{
    public class CharacterPhysicsService : IService
    {
        private PhysicSettingsData _physicSettingsData;
        private UpdaterService _updater;

        private Dictionary<Character, CharacterBody> _characterBodies = new Dictionary<Character, CharacterBody>();

        public CharacterPhysicsService(PhysicSettingsData physicSettingsData, UpdaterService updater)
        {
            _physicSettingsData = physicSettingsData;
            _updater = updater;

            _updater.AddUpdater(Update);
        }

        public void AddBody(Character character, CharacterBody characterBody)
        {
            if (_characterBodies.ContainsKey(character))
                throw new Exception("Character can only have one body");

            _characterBodies.Add(character, characterBody);
        }

        public void RemoveBody(Character character)
        {
            _characterBodies.Remove(character);
        }

        protected void Update()
        {
            foreach (var item in _characterBodies)
            {
                var character = item.Key;
                var collider = item.Value.Collider;

                //Gravitation.Adding G per second.
                character.Force += _physicSettingsData.Gravitation * Time.deltaTime;
                character.Position += character.Force * Time.deltaTime;

                // Collision calcultations
                character.IsGrounded = false;
                var hits = new Collider2D[6];
                int count = collider.OverlapCollider(_physicSettingsData.GroundCollisions, hits);
                for (int i = 0; i < count; i++)
                {
                    var hit = hits[i];
                    var colliderDistance = hit.Distance(collider);

                    if (colliderDistance.isOverlapped)
                    {
                        // Pushing backward
                        character.Position += colliderDistance.pointA - colliderDistance.pointB;

                        // Grounded if collider beneath
                        if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && character.Force.y < 0)
                        {
                            character.IsGrounded = true;

                            if (character.Force.y < 0) // Blocking falling
                                character.Force = new Vector2(character.Force.x, 0);
                        }
                    }
                }
                collider.transform.position = character.Position;
            }
        }

    }
}
