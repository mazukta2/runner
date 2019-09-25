using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Character")]
    public class CharacterData : ScriptableObject
    {
        public Character Prefab => _Prefab;
        public MovementRuleData MovementRule => _movement;

        [SerializeField] Character _Prefab;
        [SerializeField] MovementRuleData _movement;
        
    }

}
