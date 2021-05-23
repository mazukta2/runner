using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Data.World
{
    // all worlds settings
    [CreateAssetMenu(menuName = "Game/Worlds/Settings")]
    public class WorldsSettingsData : DataService
    {
        public WorldData[] Worlds => _World;

        [SerializeField] WorldData[] _World;
    }

}
