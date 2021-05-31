using Assets.Scripts.Data.Physics;
using Assets.Scripts.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Models.Services
{
    public class CharacterMovingService
    {
        private PhysicSettingsData _physicSettingsData;
        private UpdaterService _updater;

        private List<CharacterBody> _characterBodies = new List<CharacterBody>();

        public CharacterMovingService(PhysicSettingsData physicSettingsData, UpdaterService updater)
        {
            _physicSettingsData = physicSettingsData;
            _updater = updater;

            _updater.AddUpdater(Update);
        }

        protected void Update()
        {
            foreach (var character in _characterBodies)
            {
                // Gravitation. Adding G per second.
                character.Force += _physicSettingsData.Gravitation * Time.deltaTime;

                character.Position += character.Force * Time.deltaTime;

                // Collision calcultations
                character.IsGrounded = false;
                var hits = new RaycastHit2D[6];
                int count = character.GetCollisionHits(_physicSettingsData.GroundCollisions, hits);
                var bounds = character.GetBounds();
                for (int i = 0; i < count; i++)
                {
                    var hit = hits[i];
                    var contactPoint = hit.point;
                    var closestPoint = (Vector2)bounds.ClosestPoint(contactPoint);

                    // Pushing backward
                    character.Position += closestPoint - contactPoint;

                    // Grounded if collider beneath
                    if (Vector2.Angle(contactPoint.normal, Vector2.up) < 90 && character.Force.y < 0)
                    {
                        character.IsGrounded = true;

                        if (character.Force.y < 0) // Blocking falling
                            character.Force = new Vector2(character.Force.x, 0);
                    }

                    //var colliderDistance = hit.Distance();

                    //if (colliderDistance.isOverlapped)
                    //{

                    //}
                }
                _jumpRequest = false;
            }
        }

    }
}
