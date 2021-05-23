using Assets.Scripts.Components.Providers.Common.Services;
using Assets.Scripts.Data.World;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.World.WorldDataList
{
    // get all world datas
    public class AllWorldDataListProvider : WorldDataListProvider
    {
        private ServiceSystemKeeper _serviceProvider = new ServiceSystemKeeper();

        public override WorldData[] Get()
        {
            return _serviceProvider.GetServices().Get<WorldsSettingsData>().Worlds;
        }
    }
}