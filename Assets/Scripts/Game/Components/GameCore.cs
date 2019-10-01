using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameCore
    {
        public static GameCore Instance {
            get
            {
                if (_instance == null)
                    _instance = new GameCore();

                return _instance;
            }
        }

        private static GameCore _instance;

        private Dictionary<int, object> _dataSingletons = new Dictionary<int, object>();

        // Saving links of singleton instances
        public T GetDataSingletonInstance<T>(ScriptableObjectSingletonData<T> data)
        {
            if (Instance == null)
                throw new Exception("The game is not initiated.");

            object result;
            if (!_dataSingletons.TryGetValue(data.GetInstanceID(), out result))
            {
                result = data.CreateInstance(this);
                _dataSingletons.Add(data.GetInstanceID(), result);
            }

            return (T)result;
        }
    }
}
