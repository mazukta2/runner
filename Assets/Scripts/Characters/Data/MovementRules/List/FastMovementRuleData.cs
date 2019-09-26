using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Fast")]
    public class FastMovementRuleData : MovementRuleData
    {
        [SerializeField] private float _Acceleration;
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _JumpHeight;

        public override void UpdatePosition(Character view, bool jumpButton)
        {
            var forceController = view.GetComponent<PhysicObject>();

            //if (forceController.IsGrounded)
            {
                var speed = forceController.Force.x;

                if (speed < _MaxSpeed / 2)
                {
                    speed += _Acceleration * Time.deltaTime;
                }
                else
                {
                    speed = Mathf.MoveTowards(speed, Mathf.Pow(speed, 2), Time.deltaTime);
                }
                speed = Mathf.Min(speed, _MaxSpeed);
                forceController.Force = new Vector2(speed, forceController.Force.y);
            }

            if (forceController.IsGrounded && jumpButton)
            {
                forceController.Force += new Vector2(0,
                    Mathf.Sqrt(2 * _JumpHeight *
                    Mathf.Abs(forceController.Settings.Gravitation.y)));
            }
        }
    }

}
