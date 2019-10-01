using UnityEngine;
using System.Collections;

namespace Game
{
    // Controlling animations using PhysicObject properties
    public class CharacterAnimations : MonoBehaviour
    {
        [SerializeField] private PhysicObject _Physics;
        [SerializeField] private Animator _Animator;
        [SerializeField] private string _GroundedKey;
        [SerializeField] private string _RunningKey;

        private void Update()
        {
            _Animator.SetBool(_RunningKey, Mathf.Abs(_Physics.Force.x) > 0);
            _Animator.SetBool(_GroundedKey, _Physics.IsGrounded);
        }
    }

}
