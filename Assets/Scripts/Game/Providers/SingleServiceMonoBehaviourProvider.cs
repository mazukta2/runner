using Assets.Scripts.Game.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game.Providers
{
    public abstract class SingleServiceMonoBehaviourProvider<T> : MonoBehaviour where T : IService
    {
        private ServiceProvider _serviceProvider = new ServiceProvider();

        public T Get()
        {
            return _serviceProvider.GetServices().Get<T>();
        }
    }
}