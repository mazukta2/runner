using Assets.Scripts.Components.Providers.Common.Services;
using Assets.Scripts.Game.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.Common
{
    // get any service
    public abstract class SingleServiceMonoBehaviourProvider<TService> : MonoBehaviour 
        where TService : IService
    {
        private ServiceSystemKeeper _serviceProvider = new ServiceSystemKeeper();

        public TService Get()
        {
            return _serviceProvider.GetServices().Get<TService>();
        }
    }
}