using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class CharacterSelector : ListSelector<CharacterData, Character>
    {
        [SerializeField] private CharactersSettingsData _CharactersSettings;

        protected override ListDataElement[] GetList()
        {
            return _CharactersSettings.Characters.Select(x => 
                new ListDataElement
                {
                    Data = x,
                    Prefab = x.Prefab,
                }
            ).ToArray();
        }
    }
}

