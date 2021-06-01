using Assets.Scripts.Characters;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Models.Entities;
using Assets.Scripts.Models.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Characters
{
    public class CharacterBody : MonoBehaviour
    {
        public Collider2D Collider => _collider;

        [SerializeField] Collider2D _collider;
        [SerializeField] CharacterProvider.Field _characterProvider;
        [SerializeField] CharactersPhysicsProvider.Field _characterBodyProvider;

        private Character _character;
        private CharacterPhysicsService _bodyService;

        protected void Awake()
        {
            _character = _characterProvider.Get();
            _bodyService = _characterBodyProvider.Get();
            _bodyService.AddBody(_character, this);
        }

        protected void OnDestroy()
        {
            _bodyService.RemoveBody(_character);
        }

    }
}