using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Worlds/World")]
    public class WorldData : ScriptableObject
    {
        public MenuWorldView MenuPrefab => _menuViewPrefab;
        public SceneData Scene => _scene;

        [SerializeField] MenuWorldView _menuViewPrefab;
        [SerializeField] SceneData _scene;
    }

}
