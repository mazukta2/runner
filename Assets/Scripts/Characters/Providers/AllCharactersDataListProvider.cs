using Assets.Scripts.Game.Providers;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public class AllCharactersDataListProvider : CharacterDataListProvider
    {
        private ServiceProvider _serviceProvider = new ServiceProvider();

        public override CharacterData[] Get()
        {
            return _serviceProvider.GetServices().Get<CharactersSettingsData>().Characters;
        }
    }
}