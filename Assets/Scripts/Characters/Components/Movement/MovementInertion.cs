using UnityEngine;
using System.Collections;

namespace Game
{
    [RequireComponent(typeof(Character))]
    public class MovementInertion : MonoBehaviour
    {
        public Vector3 Force => _Force;

        [SerializeField] public Vector2 _Force;
        [SerializeField] public Vector2 _ForceLimit;

        private Character _character;
        private float _Gravitation;

        protected void Start()
        {
            _character = GetComponent<Character>();
        }

        public void SetForceLimit(Vector2 limit)
        {
            _ForceLimit = limit;
        }

        public void SetGravitation(float x)
        {
            _Gravitation = x;
        }

        public void AddForce(Vector2 force)
        {
            _Force += force;

            if (_Force.x > _ForceLimit.x)
                _Force = new Vector2(_ForceLimit.x, _Force.y);

            if (_Force.y > _ForceLimit.y)
                _Force = new Vector2(_Force.x, _ForceLimit.y);
        }

        private void Update()
        {
            transform.position += Force * Time.deltaTime;

            _Force = new Vector2(_Force.x, Mathf.Max(Force.y - _Gravitation, 0));
        }
    }
}
