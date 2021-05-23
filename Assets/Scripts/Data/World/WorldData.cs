using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Game.Scenes.Types;
using Assets.Scripts.Data.Physics;

namespace Assets.Scripts.Data.World
{
    // description of world
    [CreateAssetMenu(menuName = "Game/Worlds/World")]
    public class WorldData : ScriptableObject
    {
        public GameObject MainMenuView => _menuViewView;
        public LevelSceneData Scene => _scene;
        public FailSceneData FailScene => _failScene;
        public PhysicSettingsData Physics => _physics;

        [SerializeField] GameObject _menuViewView;
        [SerializeField] LevelSceneData _scene;
        [SerializeField] FailSceneData _failScene;
        [SerializeField] PhysicSettingsData _physics;
    }

}
