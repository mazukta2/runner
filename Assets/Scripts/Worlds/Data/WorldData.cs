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

        [SerializeField] MenuWorldView _menuViewPrefab;
    }

}
