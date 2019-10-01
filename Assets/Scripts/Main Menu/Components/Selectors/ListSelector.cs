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
        public abstract TData CurrentElementData { get; protected set; }

        [SerializeField] private Button _LeftButton;
        [SerializeField] private Button _RightButton;
        [SerializeField] private GameObject _Placeholder;

        private List<ListElement> _elements = new List<ListElement>();

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
            var currentElement = _elements
                .FindIndex(x => x.Data.Data == CurrentElementData);

            currentElement--;
            if (currentElement < 0)
                currentElement = _elements.Count - 1;

            CurrentElementData = _elements[currentElement].Data.Data;

            UpdateView();
        }

        private void OnRightClick()
        {
            var currentElement = _elements
                .FindIndex(x => x.Data.Data == CurrentElementData);

            currentElement++;
            if (currentElement > _elements.Count - 1)
                currentElement = 0;

            CurrentElementData = _elements[currentElement].Data.Data;

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
                item.Hidder.Show(item.Data.Data == CurrentElementData);
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
