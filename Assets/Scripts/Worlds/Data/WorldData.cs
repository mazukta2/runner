using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/World")]
    public class WorldData : ScriptableObject
    {
        public World MenuPrefab => _MenuViewPrefab;
        public SceneData Scene => _Scene;
        public GameObject[] Obstacles => _Obstacles;
        public PhysicSettingsData Physics => _Physics;

        [SerializeField] World _MenuViewPrefab;
        [SerializeField] SceneData _Scene;
        [SerializeField] GameObject[] _Obstacles;
        [SerializeField] PhysicSettingsData _Physics;
    }

}
