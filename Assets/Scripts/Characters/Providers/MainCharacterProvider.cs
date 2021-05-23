using Assets.Scripts.Characters.Services;
using Assets.Scripts.Game.Providers;
using Assets.Scripts.Session.PreSession;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public class MainCharacterProvider : CharacterProvider
    {
        private ServiceProvider _serviceProvider = new ServiceProvider();
        public override Character Get() => _serviceProvider
            .GetServices().Get<SessionService>().MainCharacter;

    }
}