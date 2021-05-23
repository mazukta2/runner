using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game.Data;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/Settings")]
    public class WorldsSettingsData : DataService
    {
        public WorldData[] Worlds => _World;

        [SerializeField] WorldData[] _World;
    }

}
