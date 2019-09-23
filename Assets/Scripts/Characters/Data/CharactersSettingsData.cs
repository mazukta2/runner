using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Settings")]
    public class CharactersSettingsData : ScriptableObject
    {
        public CharacterData CharacterByDefault => _characterByDefault;
        public CharacterData[] Characters => _characters;

        [SerializeField] CharacterData _characterByDefault;
        [SerializeField] CharacterData[] _characters;
    }

}
