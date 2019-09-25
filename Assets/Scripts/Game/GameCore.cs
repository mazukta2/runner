using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameCore : MonoBehaviour
    {
        public static GameCore Instance { get; private set; }

        [SerializeField] LoaderData _loader;

        private Dictionary<int, object> _dataSingletons = new Dictionary<int, object>();

        public void Awake()
        {
            Instance = this;
            _loader.Instance.LoadMainMenu();
        }

        // Saving links of singleton instances
        public T GetDataSingletonInstance<T>(ScriptableObjectSingletonData<T> provider)
        {
            if (Instance == null)
                throw new Exception("The game is not initiated.");

            object result;
            if (!_dataSingletons.TryGetValue(provider.GetInstanceID(), out result))
            {
                result = provider.CreateInstance(this);
                _dataSingletons.Add(provider.GetInstanceID(), result);
            }

            return (T)result;
        }
    }
}
