using Assets.Scripts.Components.Core;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.Common.Services
{
    public class ServiceSystemKeeper
    {
        private ServicesSystem _services;

        public ServicesSystem GetServices()
        {
            if (_services == null)
                _services = GameObject.FindGameObjectWithTag("GameCore")
                    .GetComponent<GameCore>()
                    .Services;

            return _services;
        }
    }
}