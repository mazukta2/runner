using Assets.Scripts.Components.Providers.Common.Services;
using Assets.Scripts.Game.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.Common
{
    // get any service
    public abstract class SingleServiceMonoBehaviourProvider<T> : MonoBehaviour where T : IService
    {
        private ServiceSystemKeeper _serviceProvider = new ServiceSystemKeeper();

        public T Get()
        {
            return _serviceProvider.GetServices().Get<T>();
        }

        [Serializable]
        public class Field : ProviderField<SingleServiceMonoBehaviourProvider<T>, T>
        {
            protected override T GetService(SingleServiceMonoBehaviourProvider<T> provider)
                => provider.Get();
        }
    }
}