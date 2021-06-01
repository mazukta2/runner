using Assets.Scripts.Data.Characters;
using UnityEngine;

namespace Assets.Scripts.Models.Entities
{
    // character model
    public class Character
    {
        public CharacterData Data { get; private set; }
        public Vector2 Position { get; set; }
        public Vector2 Force { get; set; }
        public bool IsGrounded { get; set; }

        public Character(CharacterData characterData)
        {
            Data = characterData;
        }
    }
}
