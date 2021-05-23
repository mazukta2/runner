using Assets.Scripts.Characters.Services;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Characters.Components.Views
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _groundedKey;
        [SerializeField] private string _runningKey;

        private Character _character;

        public void Set(Character character)
        {
            _character = character;
        }

        protected void Update()
        {
            if (_character == null)
                return;

            transform.position = _character.Physic.Position;
            _animator.SetBool(_runningKey, Mathf.Abs(_character.Physic.Force.x) > 0);
            _animator.SetBool(_groundedKey, _character.Physic.IsGrounded);
        }
    }
}