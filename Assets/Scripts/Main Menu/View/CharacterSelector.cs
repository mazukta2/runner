using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class CharacterSelector : MonoBehaviour
    {
        [SerializeField] private CharactersSettingsData _CharactersSettings;
        [SerializeField] private Button _LeftButton;
        [SerializeField] private Button _RightButton;
        [SerializeField] private GameObject _CharacterPlaceholder;

        private List<Character> _characters = new List<Character>();
        private int _currentCharacter;

        private void Start()
        {
            _LeftButton.onClick.AddListener(OnLeftClick);
            _RightButton.onClick.AddListener(OnRightClick);

            CreateCharacters();
            SetDefaultCharacter();
        }

        private void OnDestroy()
        {
            if (_LeftButton)
                _LeftButton.onClick.RemoveListener(OnLeftClick);

            if (_RightButton)
                _RightButton.onClick.RemoveListener(OnRightClick);
        }

        private void OnLeftClick()
        {
            _currentCharacter--;
            if (_currentCharacter < 0)
                _currentCharacter = _characters.Count - 1;

            ShowCharacter(_characters[_currentCharacter].Data);
        }

        internal CharacterData GetCharacter()
        {
            return _characters[_currentCharacter].Data;
        }

        private void OnRightClick()
        {
            _currentCharacter++;
            if (_currentCharacter > _characters.Count - 1)
                _currentCharacter = 0;

            ShowCharacter(_characters[_currentCharacter].Data);
        }

        private void CreateCharacters()
        {
            foreach (var item in _CharactersSettings.Characters)
            {
                var go = Instantiate(item.Prefab, _CharacterPlaceholder.transform);
                var view = go.GetComponent<Character>();
                view.Data = item;
                var hidder = go.GetComponent<GameObjectHidder>();
                hidder.Show(false);
                _characters.Add(view);
            }
        }

        private void SetDefaultCharacter()
        {
            _currentCharacter = _characters.IndexOf(
                _characters.First(x => x.Data == _CharactersSettings.CharacterByDefault));
            ShowCharacter(_CharactersSettings.CharacterByDefault);
        }

        private void ShowCharacter(CharacterData character)
        {
            foreach (var item in _characters)
            {
                var hidder = item.GetComponent<GameObjectHidder>();
                hidder.Show(item.Data == character);
            }
        }
    }
}

