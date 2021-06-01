using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Models.Entities;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    // character model
    public abstract class CharacterProvider : MonoBehaviour
    {
        public abstract Character GetCharacter();

        [Serializable]
        public class Field : ProviderField<CharacterProvider, Character>
        {
            protected override Character GetService(CharacterProvider provider) 
                => provider.GetCharacter();
        }
    }
}