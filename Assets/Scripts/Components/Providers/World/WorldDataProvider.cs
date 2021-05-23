using Assets.Scripts.Data.World;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Providers.World
{
    // any world data
    public abstract class WorldDataProvider : MonoBehaviour
    {
        public abstract WorldData Get();
    }
}