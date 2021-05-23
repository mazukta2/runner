using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Data.Characters;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    // Get character datas
    public abstract class CharacterDataListProvider : MonoBehaviour
    {
        public abstract CharacterData[] Get();

        [Serializable]
        public class Field : ProviderField<CharacterDataListProvider, CharacterData[]>
        {
            protected override CharacterData[] GetService(CharacterDataListProvider provider)
                => provider.Get();
        }
    }
}