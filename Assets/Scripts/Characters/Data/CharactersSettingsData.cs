using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Settings")]
    public class CharactersSettingsData : ScriptableObject
    {
        public CharacterData[] Characters => _Characters;

        [SerializeField] CharacterData[] _Characters;
    }

}
