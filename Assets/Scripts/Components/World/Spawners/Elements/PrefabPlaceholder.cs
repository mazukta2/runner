using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public class PrefabPlaceholder : EndlessLineElement
    {
        [SerializeField] GameObject[] _Prefabs;
        [SerializeField] bool _RespawnOnRelocation;

        protected void Start()
        {
            Spawn();
        }

        public override void Replaced()
        {
            if (!_RespawnOnRelocation)
                return;

            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);

            var index = UnityEngine.Random.Range(0, _Prefabs.Length);
            var obstacle = _Prefabs[index];
            Instantiate(obstacle, transform);
        }
    }

}
