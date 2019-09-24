using UnityEngine;
using System.Collections;
using Game;
using System;

namespace Game
{
    public class MenuWorldView : MonoBehaviour
    {
        public WorldData World => _world;

        [SerializeField] private GameObject _View;

        private WorldData _world;

        public void Show(bool value)
        {
            _View.SetActive(value);
        }

        internal void Init(WorldData world)
        {
            _world = world;
        }
    }
}

