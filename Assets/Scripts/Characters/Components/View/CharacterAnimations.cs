using UnityEngine;
using System.Collections;

namespace Game
{
    public class CharacterAnimations : MonoBehaviour
    {
        [SerializeField] private PhysicObject _Physics;
        [SerializeField] private Animator _Animator;
        [SerializeField] private string _GroundedKey;
        [SerializeField] private string _RunningKey;

        void Update()
        {
            _Animator.SetBool(_RunningKey, Mathf.Abs(_Physics.Force.x) > 0);
            _Animator.SetBool(_GroundedKey, _Physics.IsGrounded);
        }
    }

}
