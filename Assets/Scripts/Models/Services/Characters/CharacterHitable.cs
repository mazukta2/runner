using UnityEngine;
using System.Collections;
using Assets.Scripts.Physics.Services;
using Assets.Scripts.Characters.Settings;

namespace Assets.Scripts.Characters.Services
{
    public class CharacterHitable 
    {
        private CharacterData _characterData;
        private CharacterPhysic _physics;

        public CharacterHitable(CharacterData characterData,
            CharacterPhysic physic)
        {
            _characterData = characterData;
            _physics = physic;
        }

        public bool IsCollidingWithDanger()
        {
            return _physics.IsCollidingWith(_characterData.DangerHiting);
        }
    }
}
