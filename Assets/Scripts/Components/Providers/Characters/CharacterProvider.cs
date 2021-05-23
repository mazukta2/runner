using Assets.Scripts.Characters.Services;
using Assets.Scripts.Common.Providers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
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