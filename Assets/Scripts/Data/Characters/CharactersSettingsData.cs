using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game.Data;

namespace Assets.Scripts.Characters.Settings
{
    [CreateAssetMenu(menuName = "Game/Characters/Settings")]
    public class CharactersSettingsData : DataService
    {
        public CharacterData[] Characters => _characters;

        [SerializeField] CharacterData[] _characters;
    }

}
