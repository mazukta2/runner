using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Characters.Services;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Fast")]
    public class FastMovementRuleData : MovementRuleData
    {
        [SerializeField] private float _Acceleration;
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _JumpHeight;

        public override void Move(Character character, bool jump)
        {
            var physic = character.Physic;
            var speed = physic.Force.x;
            if (speed < _MaxSpeed / 2)
                speed += _Acceleration * Time.deltaTime;
            else
                speed = Mathf.MoveTowards(speed,
                    Mathf.Pow(speed, 2), Time.deltaTime);

            speed = Mathf.Min(speed, _MaxSpeed);
            physic.Force = new Vector2(speed, physic.Force.y);
            if (physic.IsGrounded && jump)
            {
                physic.Force += new Vector2(0,
                    Mathf.Sqrt(2 * _JumpHeight));
            }
        }
    }

}
