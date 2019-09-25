using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public abstract class ListSelector<TData, TComponent> : MonoBehaviour 
        where TData : ScriptableObject
        where TComponent : MonoBehaviour
    {
        public TData CurrentElementData => _elements[_currentElement].Data.Data;

        [SerializeField] private Button _LeftButton;
        [SerializeField] private Button _RightButton;
        [SerializeField] private GameObject _Placeholder;

        private List<ListElement> _elements = new List<ListElement>();
        private int _currentElement;

        private void Start()
        {
            _LeftButton.onClick.AddListener(OnLeftClick);
            _RightButton.onClick.AddListener(OnRightClick);

            CreateAll();
            UpdateView();
        }

        private void OnDestroy()
        {
            if (_LeftButton)
                _LeftButton.onClick.RemoveListener(OnLeftClick);

            if (_RightButton)
                _RightButton.onClick.RemoveListener(OnRightClick);
        }

        protected abstract ListDataElement[] GetList();

        private void OnLeftClick()
        {
            _currentElement--;
            if (_currentElement < 0)
                _currentElement = _elements.Count - 1;

            UpdateView();
        }

        private void OnRightClick()
        {
            _currentElement++;
            if (_currentElement > _elements.Count - 1)
                _currentElement = 0;

            UpdateView();
        }

        private void CreateAll()
        {
            foreach (var item in GetList())
            {
                var go = Instantiate(item.Prefab.gameObject, _Placeholder.transform);
                var hidder = go.GetComponent<GameObjectHidder>();
                hidder.Show(false);

                _elements.Add(new ListElement() {
                    Data = item,
                    Component = go.GetComponent<TComponent>(),
                    Hidder = hidder,
                });
            }
        }

        private void UpdateView()
        {
            foreach (var item in _elements)
            {
                item.Hidder.Show(item.Data.Data == _elements[_currentElement].Data.Data);
            }
        }

        protected class ListDataElement
        {
            public TData Data;
            public TComponent Prefab;
        }

        protected class ListElement
        {
            public ListDataElement Data;
            public TComponent Component;
            public GameObjectHidder Hidder;
        }
    }

}
