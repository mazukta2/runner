using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class CharacterSelector : ListSelector<CharacterData, CharacterModel>
    {
        [SerializeField] private SessionProvider _Session;
        [SerializeField] private CharactersSettingsData _CharactersSettings;

        public override CharacterData CurrentElementData
        {
            get => _Session.Instance.Character;
            protected set => _Session.Instance.Character = value;
        }

        protected override ListDataElement[] GetList()
        {
            return _CharactersSettings.Characters.Select(x => 
                new ListDataElement
                {
                    Data = x,
                    Prefab = x.Model,
                }
            ).ToArray();
        }
    }
}

