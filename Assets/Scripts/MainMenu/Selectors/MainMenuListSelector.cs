﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Game;
using System;

namespace Assets.Scripts.MainMenu.Selectors
{
    public class MainMenuListSelector : MonoBehaviour
    {
        public int Index => _currentIndex;

        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;
        [SerializeField] private GameObject _placeholder;

        private int _elementsCount;
        private Action _updateModel;
        private Func<int, GameObject> _getModel;
        private int _currentIndex;
        private GameObject _currentElement;

        public void Init(int index, int length, Action updateModel, Func<int, GameObject> getModel)
        {
            _currentIndex = index;
            _elementsCount = length;
            _updateModel = updateModel;
            _getModel = getModel;
        }

        protected void Awake()
        {
            _previousButton.onClick.AddListener(OnPrevClick);
            _nextButton.onClick.AddListener(OnNextClick);
        }

        protected void Start()
        {
            UpdateModel();
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
                _currentIndex = _elementsCount - 1;

            UpdateModel();
            UpdateView();
        }

        private void OnNextClick()
        {
            _currentIndex++;
            if (_currentIndex > _elementsCount - 1)
                _currentIndex = 0;

            UpdateModel();
            UpdateView();
        }

        private void UpdateModel()
        {
            _updateModel();
        }

        private void UpdateView()
        {
            if (_currentElement != null)
                Destroy(_currentElement);

            var go = Instantiate(_getModel(_currentIndex), _placeholder.transform);
            _currentElement = go;
        }
    }

}
