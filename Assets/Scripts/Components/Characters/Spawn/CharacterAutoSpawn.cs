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
        [SerializeField] CharacterProvider.Field _characterProvider;

        protected void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var modelGo = Instantiate(_characterProvider.Get().Data.View, transform);
            modelGo.GetComponent<CharacterView>().Set(_characterProvider.Get());
        }
    }
}
