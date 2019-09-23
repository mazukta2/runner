using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class WorldSelector : MonoBehaviour
    {
        [SerializeField] private WorldsSettingsData _WorldsSettings;
        [SerializeField] private Button _LeftButton;
        [SerializeField] private Button _RightButton;
        [SerializeField] private GameObject _WorldPlaceholder;

        private List<MenuWorldView> _worlds = new List<MenuWorldView>();
        private int _currentWorld;

        private void Start()
        {
            _LeftButton.onClick.AddListener(OnLeftClick);
            _RightButton.onClick.AddListener(OnRightClick);

            CreateWorlds();
            SetDefault();
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
            _currentWorld--;
            if (_currentWorld < 0)
                _currentWorld = _worlds.Count - 1;

            UpdateView();
        }

        private void OnRightClick()
        {
            _currentWorld++;
            if (_currentWorld > _worlds.Count - 1)
                _currentWorld = 0;

            UpdateView();
        }

        internal WorldData GetWorld()
        {
            return _worlds[_currentWorld].World;
        }

        private void CreateWorlds()
        {
            foreach (var item in _WorldsSettings.Worlds)
            {
                var go = Instantiate(item.MenuPrefab, _WorldPlaceholder.transform);
                var view = go.GetComponent<MenuWorldView>();
                view.Init(item);
                view.Show(false);
                _worlds.Add(view);
            }
        }

        private void SetDefault()
        {
            _currentWorld = _worlds.IndexOf(
                _worlds.First(x => x.World == _WorldsSettings.WorldByDefault));

            UpdateView();
        }

        private void UpdateView()
        {
            foreach (var item in _worlds)
            {
                item.Show(item.World == _worlds[_currentWorld].World);
            }
        }
    }
}

