using Assets.Scripts.Characters.Settings;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.Characters
{
    // Character representation
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _groundedKey;
        [SerializeField] private string _runningKey;

        [SerializeField] CharacterProvider.Field _characterProvider;

        protected void Update()
        {
            var character = _characterProvider.Get();
            transform.position = character.Body.Position;
            _animator.SetBool(_runningKey, Mathf.Abs(character.Body.Force.x) > 0);
            _animator.SetBool(_groundedKey, character.Body.IsGrounded);
        }
    }
}