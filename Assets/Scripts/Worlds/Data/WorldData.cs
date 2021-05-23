using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Game.Scenes.Types;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/World")]
    public class WorldData : ScriptableObject
    {
        public GameObject MainMenuPrefab => _menuViewPrefab;
        public LevelSceneData Scene => _scene;
        public FailSceneData FailScene => _failScene;
        public GameObject[] Obstacles => _obstacles;
        public PhysicSettingsData Physics => _physics;

        [SerializeField] GameObject _menuViewPrefab;
        [SerializeField] LevelSceneData _scene;
        [SerializeField] FailSceneData _failScene;
        [SerializeField] GameObject[] _obstacles;
        [SerializeField] PhysicSettingsData _physics;
    }

}
