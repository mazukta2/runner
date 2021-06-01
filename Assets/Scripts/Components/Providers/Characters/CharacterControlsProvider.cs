using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Data.Characters;
using Assets.Scripts.Models.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class CharacterControlsProvider : SingleServiceMonoBehaviourProvider<CharacterControlsService>
    {
        [Serializable]
        public class Field : ProviderField<CharacterControlsProvider, CharacterControlsService>
        {
            protected override CharacterControlsService GetService(CharacterControlsProvider provider)
                => provider.Get();
        }
    }
}