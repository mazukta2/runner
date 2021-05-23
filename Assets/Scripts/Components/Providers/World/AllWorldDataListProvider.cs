using Assets.Scripts.Game.Providers;
using Game;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    public class AllWorldDataListProvider : WorldDataListProvider
    {
        private ServiceProvider _serviceProvider = new ServiceProvider();

        public override WorldData[] Get()
        {
            return _serviceProvider.GetServices().Get<WorldsSettingsData>().Worlds;
        }
    }
}