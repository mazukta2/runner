using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/Settings")]
    public class WorldsSettingsData : ScriptableObject
    {
        public WorldData WorldByDefault => _worldByDefault;
        public WorldData[] Worlds => _world;

        [SerializeField] WorldData _worldByDefault;
        [SerializeField] WorldData[] _world;
    }

}
