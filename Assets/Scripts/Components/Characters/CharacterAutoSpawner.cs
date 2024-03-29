﻿using UnityEngine;
using Assets.Scripts.Characters.Settings;
using static Assets.Scripts.Characters.Settings.PrefabCharacterProvider;
using Assets.Scripts.Models.Entities;

namespace Assets.Scripts.Components.Characters
{
    // Create a character view on start.
    public class CharacterAutoSpawner : MonoBehaviour, 
        ICharacterProxy
    {
        public Character GetCharacter() => _characterProvider.Get();

        [SerializeField] CharacterProvider.Field _characterProvider;
        
        protected void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            GameObject.Instantiate(_characterProvider.Get().Data.LevelView, transform);
        }

    }
}
