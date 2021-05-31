using UnityEngine;
using Assets.Scripts.Data.Physics;
using Assets.Scripts.Data.Characters;
using Assets.Scripts.Models.Services;
using UnityEngine.EventSystems;
using System;

namespace Assets.Scripts.Models.Entities
{
    public class CharacterBody
    {
        public Vector2 Position { get; set; }
        public Vector2 Force { get; set; }
        public bool IsGrounded { get; set; }
        // 
        private PhysicSettingsData _settings;
        private CharactersSettingsData _charactersSettings;
        private bool _jumpRequest;
        

        public CharacterBody(PhysicSettingsData physicSettingsData,
            CharactersSettingsData charactersSettings)
        {
            _settings = physicSettingsData;
            _charactersSettings = charactersSettings;
        }

        public int GetCollisionHits(ContactFilter2D filter, RaycastHit2D[] hits)
        {
            return Physics2D.BoxCast(Position, _charactersSettings.Size, 0, Vector2.zero, filter, hits);
        }

        public bool IsCollidingWith(ContactFilter2D contactFilter2D)
        {
            var hits = new Collider2D[1];
            return Physics2D.OverlapBox(Position, _charactersSettings.Size, 0, contactFilter2D, hits) > 0;
        }

        public bool IsCollidingWithDanger()
        {
            return IsCollidingWith(_charactersSettings.DangerCollision);
        }

        public Bounds GetBounds()
        {
            return new Bounds(Position, _charactersSettings.Size);
        }

        public void Jump()
        {
            _jumpRequest = true;
        }
    }
}
