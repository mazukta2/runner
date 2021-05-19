using Assets.Scripts.Game.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game.Providers
{
    public class ServiceProvider 
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