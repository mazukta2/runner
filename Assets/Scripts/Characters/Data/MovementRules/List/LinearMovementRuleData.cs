using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Linear")]
    public class LinearMovementRuleData : MovementRuleData
    {
        [SerializeField] private float _Acceleration;
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _JumpHeight;

        public override void Move(CharacterController character, bool jump)
        {
            //var physic = character.Physic;

            //var speed = physic.Force.x;
            //speed += _Acceleration * Time.deltaTime;
            //speed = Mathf.Min(speed, _MaxSpeed);
            //physic.Force = new Vector2(speed, physic.Force.y);

            //if (physic.IsGrounded && jump)
            //{
            //    physic.Force += new Vector2(0, 
            //        Mathf.Sqrt(2 * _JumpHeight *
            //        Mathf.Abs(physic.Settings.Gravitation.y)));
            //}
        }
    }

}
