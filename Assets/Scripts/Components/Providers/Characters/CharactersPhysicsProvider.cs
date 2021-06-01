using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Data.Characters;
using Assets.Scripts.Models.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class CharactersPhysicsProvider : SingleServiceMonoBehaviourProvider<CharacterPhysicsService>
    {
        [Serializable]
        public class Field : ProviderField<CharactersPhysicsProvider, CharacterPhysicsService>
        {
            protected override CharacterPhysicsService GetService(CharactersPhysicsProvider provider)
                => provider.Get();
        }
    }
}