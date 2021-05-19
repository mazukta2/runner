using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Game;

namespace Assets.Scripts.MainMenu.Selectors
{
    public abstract class MainMenuListSelector<TData, TComponent> : MonoBehaviour
        where TData : ScriptableObject
        where TComponent : MonoBehaviour
    {
        //public abstract TData CurrentElement { get; protected set; }

        //[SerializeField] private Button _previousButton;
        //[SerializeField] private Button _nextButton;
        //[SerializeField] private GameObject _placeholder;

        ////private List<ListElement> _elements = new List<ListElement>();

        //protected void Start()
        //{
        //    _previousButton.onClick.AddListener(OnPrevClick);
        //    _nextButton.onClick.AddListener(OnNextClick);

        //    CreateAll();
        //    UpdateView();
        //}

        //protected void OnDestroy()
        //{
        //    _previousButton.onClick.RemoveListener(OnPrevClick);
        //    _nextButton.onClick.RemoveListener(OnNextClick);
        //}

        //protected abstract ListDataElement[] GetList();

        //private void OnPrevClick()
        //{
        //    var currentElement = _elements
        //        .FindIndex(x => x.Data.Data == CurrentElement);

        //    currentElement--;
        //    if (currentElement < 0)
        //        currentElement = _elements.Count - 1;

        //    CurrentElement = _elements[currentElement].Data.Data;

        //    UpdateView();
        //}

        //private void OnNextClick()
        //{
        //    var currentElement = _elements
        //        .FindIndex(x => x.Data.Data == CurrentElement);

        //    currentElement++;
        //    if (currentElement > _elements.Count - 1)
        //        currentElement = 0;

        //    CurrentElement = _elements[currentElement].Data.Data;

        //    UpdateView();
        //}

        //private void CreateAll()
        //{
        //    foreach (var item in GetList())
        //    {
        //        var go = Instantiate(item.Prefab.gameObject, _placeholder.transform);
        //        var hidder = go.GetComponent<GameObjectHidder>();
        //        hidder.Show(false);

        //        _elements.Add(new ListElement()
        //        {
        //            Data = item,
        //            Component = go.GetComponent<TComponent>(),
        //            Hidder = hidder,
        //        });
        //    }
        //}

        //private void UpdateView()
        //{
        //    foreach (var item in _elements)
        //    {
        //        item.Hidder.Show(item.Data.Data == CurrentElement);
        //    }
        //}

        //protected class ListDataElement
        //{
        //    public TData Data;
        //    public TComponent Prefab;
        //}

        //protected class ListElement
        //{
        //    public ListDataElement Data;
        //    public TComponent Component;
        //    public GameObjectHidder Hidder;
        //}
    }

}
