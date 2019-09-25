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
        public Vector2 Gravitation => _Gravitation;

        [SerializeField] World _MenuViewPrefab;
        [SerializeField] SceneData _Scene;
        [SerializeField] GameObject[] _Obstacles;
        [SerializeField] Vector2 _Gravitation;
    }

}
