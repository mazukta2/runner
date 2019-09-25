using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/Settings")]
    public class WorldsSettingsData : ScriptableObject
    {
        public WorldData[] Worlds => _World;

        [SerializeField] WorldData[] _World;
    }

}
