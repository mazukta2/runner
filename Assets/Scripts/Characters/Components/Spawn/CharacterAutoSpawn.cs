using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters.Services;
using Game;
using Assets.Scripts.Characters.Components.Views;

namespace Assets.Scripts.Characters.Components.Spawn
{
    public class CharacterAutoSpawn : MonoBehaviour
    {
        [SerializeField] CharacterProvider _characterProvider;
        [SerializeField] WorldProvider _worldProvider;

        private Character _character;
        private WorldData _world;

        protected void Awake()
        {
            _character = _characterProvider.Get();
            _world = _worldProvider.Get();
        }

        protected void Start()
        {
            Spawn();
        }

        protected void OnDestroy()
        {
        }

        private void Spawn()
        {
            var modelGo = Instantiate(_character.Data.View, transform);
            modelGo.GetComponent<CharacterView>().Set(_character);
        }
    }
}
