using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Data.World;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.World
{
    // list of any datas
    public abstract class WorldDataListProvider : MonoBehaviour
    {
        public abstract WorldData[] Get();

        [Serializable]
        public class Field : ProviderField<WorldDataListProvider, WorldData[]>
        {
            protected override WorldData[] GetService(WorldDataListProvider provider)
                => provider.Get();
        }
    }
}