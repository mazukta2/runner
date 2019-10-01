using UnityEngine;
using System.Collections;

namespace Game
{
    [RequireComponent(typeof(Collider2D))]
    public class Hitable : MonoBehaviour
    {
        [SerializeField] private ContactFilter2D _CollisionFilter;

        private Collider2D _collider;

        protected void Start()
        {
            _collider = GetComponent<Collider2D>();
        }

        public bool IsCollideWithDanger()
        {
            var hits = new Collider2D[6];
            int count = _collider.OverlapCollider(_CollisionFilter, hits);
            return count > 0;
        }
    }
}
