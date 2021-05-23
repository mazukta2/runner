using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.MainMenu.Selectors;
using Game;
using Assets.Scripts.MainMenu.Providers;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Session.PreSession;

namespace Assets.Scripts.MainMenu.Selectors.List
{
    [RequireComponent(typeof(MainMenuListSelector))]
    public class WorldSelector : MonoBehaviour
    {
        [SerializeField] private PreSessionProvider _preSessionProvider;
        [SerializeField] private WorldDataListProvider _worldsListProviders;

        private MainMenuListSelector _selector;

        private PreSessionService _preSession;
        private WorldData[] _elements;

        protected void Awake()
        {
            _selector = GetComponent<MainMenuListSelector>();
            _preSession = _preSessionProvider.Get();
            _elements = _worldsListProviders.Get();
            _selector.Init(0, _elements.Length, UpdatePreSession, GetModel);
        }

        private void UpdatePreSession()
        {
            _preSession.SetWorld(_elements[_selector.Index]);
        }

        private GameObject GetModel(int index)
        {
            return _elements[index].MainMenuPrefab;
        }
    }
}

