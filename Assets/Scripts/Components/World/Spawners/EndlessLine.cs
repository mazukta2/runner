using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Components.World.Spawners
{
    // Endless line of objects. its spawns some almount of elements
    // around moving point and relocate them if this moint is changed
    // position.
    public class EndlessLine : MonoBehaviour
    {
        [SerializeField] private EndlessLineElement _elementPrefab;
        [SerializeField] private GameObject _movingPoint;

        [SerializeField] private int _partsCount;
        [SerializeField] private float _partSize;
        [SerializeField] private float _offset;

        private List<EndlessLineElement> _spawned = new List<EndlessLineElement>();

        protected void Start()
        {
            // Create all parts on start
            for (int i = 0; i < _partsCount; i++)
            {
                var go = Instantiate(_elementPrefab, transform);
                go.transform.localPosition = new Vector3(i * _partSize, 0);
                var element = go.GetComponent<EndlessLineElement>();
                _spawned.Add(element);

                element.Replaced();
            }
        }

        protected void Update()
        {
            if (_spawned.Count == 0)
                return;

            // Move left parts to right
            if (_spawned[0].transform.position.x < _movingPoint.transform.position.x + _offset)
            {
                var left = _spawned[0];
                var right = _spawned[_spawned.Count - 1];

                _spawned.RemoveAt(0);
                _spawned.Add(left);

                left.transform.localPosition = new Vector3(right.transform.localPosition.x + _partSize, 0);

                left.GetComponent<EndlessLineElement>().Replaced();
            }
        }
    }

}
