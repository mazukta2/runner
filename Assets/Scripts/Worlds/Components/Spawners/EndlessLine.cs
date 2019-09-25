using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class EndlessLine : MonoBehaviour
    {
        [SerializeField] private EndlessLineElement _ElementPrefab;
        [SerializeField] private GameObject _MovingPoint;

        [SerializeField] private int _PartsCount;
        [SerializeField] private float _PartSize;
        [SerializeField] private float _Offset;

        private List<EndlessLineElement> _spawned = new List<EndlessLineElement>();

        protected void Start()
        {
            // Create all parts on start
            for (int i = 0; i < _PartsCount; i++)
            {
                var go = Instantiate(_ElementPrefab, transform);
                go.transform.localPosition = new Vector3(i * _PartSize, 0);
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
            if (_spawned[0].transform.position.x < _MovingPoint.transform.position.x + _Offset)
            {
                var left = _spawned[0];
                var right = _spawned[_spawned.Count - 1];

                _spawned.RemoveAt(0);
                _spawned.Add(left);

                left.transform.localPosition = new Vector3(right.transform.localPosition.x + _PartSize, 0);

                left.GetComponent<EndlessLineElement>().Replaced();
            }
        }
    }

}
