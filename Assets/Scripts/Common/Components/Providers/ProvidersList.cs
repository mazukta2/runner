using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Game
{
    public class ProvidersList<T>
    {
        public event EventHandler OnRegister = delegate { };
        public event EventHandler OnUnRegister = delegate { };

        public T[] List => _providers.ToArray();
        private List<T> _providers = new List<T>();

        public void Reqister(T provider)
        {
            _providers.Add(provider);
            OnRegister(provider, EventArgs.Empty);
        }

        public void UnReqister(T provider)
        {
            _providers.Remove(provider);
            OnUnRegister(provider, EventArgs.Empty);
        }
    }

}
