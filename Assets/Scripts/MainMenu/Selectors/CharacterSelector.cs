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
    public class CharacterSelector : MonoBehaviour
    {
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private GameObject _placeholder;

        [SerializeField] private PreSessionProvider _preSessionProvider;
        [SerializeField] private CharacterDataListProvider _charactersProviders;

        private PreSessionService _preSession;
        private CharacterData[] _elements;
        private int _currentIndex;
        private GameObject _currentElement;

        protected void Awake()
        {
            _preSession = _preSessionProvider.Get();
            _elements = _charactersProviders.Get();

            _previousButton.onClick.AddListener(OnPrevClick);
            _nextButton.onClick.AddListener(OnNextClick);
        }

        protected void Start()
        {
            UpdateView();
        }

        protected void OnDestroy()
        {
            _previousButton.onClick.RemoveListener(OnPrevClick);
            _nextButton.onClick.RemoveListener(OnNextClick);
        }

        private void OnPrevClick()
        {
            _currentIndex--;
            if (_currentIndex < 0)
                _currentIndex = _elements.Length - 1;

            UpdatePreSession();
            UpdateView();
        }

        private void OnNextClick()
        {
            _currentIndex++;
            if (_currentIndex > _elements.Length - 1)
                _currentIndex = 0;

            UpdatePreSession();
            UpdateView();
        }

        private void UpdatePreSession()
        {
            _preSession.SetCharacter(_elements[_currentIndex]);
        }

        private void UpdateView()
        {
            if (_currentElement != null)
                Destroy(_currentElement);

            var currentCharacterData = _elements[_currentIndex];

            var go = Instantiate(currentCharacterData.Model, _placeholder.transform);
            _currentElement = go;
        }

    }
}

