using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        [SerializeField] private GameData _Game;
        [SerializeField] private GameObject _Prefab;
        [SerializeField] private GameObject _Point;
        [SerializeField] private int _Parts;
        [SerializeField] private float _PartSize;
        [SerializeField] private float _LeftCut;

        private List<GameObject> _spawned = new List<GameObject>();

        private void Start()
        {
            // Create all parts on start
            for (int i = 0; i < _Parts; i++)
            {
                var go = Instantiate(_Prefab, transform);
                go.transform.localPosition = new Vector3(i * _PartSize, 0);
                _spawned.Add(go);
                go.GetComponent<ObstaclePlaceholder>().World = _Game.Instance.Session.World;
                go.GetComponent<ObstaclePlaceholder>().Respawn();
            }
        }

        private void Update()
        {
            // Move left parts to right

            if (_spawned[0].transform.position.x < _Point.transform.position.x - _LeftCut)
            {
                var left = _spawned[0];
                var right = _spawned[_spawned.Count - 1];
                _spawned.RemoveAt(0);
                _spawned.Add(left);

                left.transform.localPosition = new Vector3(right.transform.localPosition.x + _PartSize, 0);
                left.GetComponent<ObstaclePlaceholder>().Respawn();
            }
        }

    }

}
