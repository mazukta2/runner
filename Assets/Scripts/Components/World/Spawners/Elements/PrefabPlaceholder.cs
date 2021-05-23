using UnityEngine;

namespace Assets.Scripts.Components.World.Spawners.Elements
{
    // this class spawns prefab on activation and respawn it
    // if element was relocated.
    public class PrefabPlaceholder : EndlessLineElement
    {
        [SerializeField] GameObject[] _prefabs;
        [SerializeField] bool _respawnOnRelocation;

        protected void Start()
        {
            Spawn();
        }

        public override void Replaced()
        {
            if (!_respawnOnRelocation)
                return;

            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);

            var index = UnityEngine.Random.Range(0, _prefabs.Length);
            var obstacle = _prefabs[index];
            Instantiate(obstacle, transform);
        }
    }

}
