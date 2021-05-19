using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game.Scenes;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/World")]
    public class WorldData : ScriptableObject
    {
        public MenuWorld MenuPrefab => _MenuViewPrefab;
        public SceneInfo Scene => _Scene;
        public GameObject[] Obstacles => _Obstacles;
        public PhysicSettingsData Physics => _Physics;

        [SerializeField] MenuWorld _MenuViewPrefab;
        [SerializeField] SceneInfo _Scene;
        [SerializeField] GameObject[] _Obstacles;
        [SerializeField] PhysicSettingsData _Physics;
    }

}
