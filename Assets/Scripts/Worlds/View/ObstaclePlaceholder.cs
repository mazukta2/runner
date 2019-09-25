using UnityEngine;
using System.Collections;
using System;

namespace Game
{
    public class ObstaclePlaceholder : MonoBehaviour
    {
        public WorldData World { get => _World; set => _World = value; }

        [SerializeField] WorldData _World;

        public void Respawn()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            var obstacle = _World.Obstacles[UnityEngine.Random.Range(0, _World.Obstacles.Length - 1)];
            Instantiate(obstacle, transform);
        }
    }

}
