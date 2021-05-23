using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.MainMenu.Selectors;
using Assets.Scripts.MainMenu.Providers;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Session.PreSession;

namespace Game
{
    [RequireComponent(typeof(MainMenuListSelector))]
    public class CharacterSelector : MonoBehaviour
    {
        [SerializeField] private PreSessionProvider _preSessionProvider;
        [SerializeField] private CharacterDataListProvider _charactersProviders;

        private MainMenuListSelector _selector;
        private PreSessionService _preSession;
        private CharacterData[] _elements;

        protected void Awake()
        {
            _preSession = _preSessionProvider.Get();
            _elements = _charactersProviders.Get();

            _selector = GetComponent<MainMenuListSelector>();
            _selector.Init(0, _elements.Length, UpdatePreSession, GetModel);
        }

        private void UpdatePreSession()
        {
            _preSession.SetCharacter(_elements[_selector.Index]);
        }

        private GameObject GetModel(int index)
        {
            return _elements[index].Model;
        }

    }
}

