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

        private List<CharacterView> _characters = new List<CharacterView>();
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

            ShowCharacter(_characters[_currentCharacter].Character);
        }

        internal CharacterData GetCharacter()
        {
            return _characters[_currentCharacter].Character;
        }

        private void OnRightClick()
        {
            _currentCharacter++;
            if (_currentCharacter > _characters.Count - 1)
                _currentCharacter = 0;

            ShowCharacter(_characters[_currentCharacter].Character);
        }

        private void CreateCharacters()
        {
            foreach (var item in _CharactersSettings.Characters)
            {
                var go = Instantiate(item.ViewPrefab, _CharacterPlaceholder.transform);
                var view = go.GetComponent<CharacterView>();
                view.Init(item);
                view.Show(false);
                _characters.Add(view);
            }
        }

        private void SetDefaultCharacter()
        {
            _currentCharacter = _characters.IndexOf(
                _characters.First(x => x.Character == _CharactersSettings.CharacterByDefault));
            ShowCharacter(_CharactersSettings.CharacterByDefault);
        }

        private void ShowCharacter(CharacterData character)
        {
            foreach (var item in _characters)
            {
                item.Show(item.Character == character);
            }
        }
    }
}

