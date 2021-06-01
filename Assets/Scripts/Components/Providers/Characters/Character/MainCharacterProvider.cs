using Assets.Scripts.Components.Providers.Common.Services;
using Assets.Scripts.Models.Entities;
using Assets.Scripts.Models.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    // get main character
    public class MainCharacterProvider : CharacterProvider
    {
        private ServiceSystemKeeper _serviceProvider = new ServiceSystemKeeper();
        public override Character GetCharacter() => _serviceProvider
            .GetServices().Get<SessionService>().MainCharacter;

    }
}