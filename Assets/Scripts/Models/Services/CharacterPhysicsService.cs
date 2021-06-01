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

                character.Force += _physicSettingsData.Gravitation * Time.deltaTime;

                var hits = new RaycastHit2D[1];
                character.IsGrounded = collider.Raycast(Vector2.down,
                    _physicSettingsData.GroundCollisions, hits, character.Force.y) > 0;

                if (character.IsGrounded && character.Force.y < 0)
                {
                    character.Force = new Vector2(character.Force.x, 0);
                    character.Position = new Vector2(character.Position.x, hits[0].point.y);
                }

                character.Position += character.Force * Time.deltaTime;
                collider.transform.position = character.Position;
            }
        }
    }
}
