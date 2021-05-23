using Assets.Scripts.Game.Providers;
using Assets.Scripts.Session.PreSession;
using Game;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public class CurrentSessionWorldProvider : WorldProvider
    {
        private ServiceProvider _serviceProvider = new ServiceProvider();

        public override WorldData Get() => _serviceProvider
            .GetServices().Get<SessionService>().WorldData;
        
    }
}