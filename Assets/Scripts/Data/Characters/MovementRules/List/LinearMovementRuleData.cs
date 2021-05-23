using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Models.Services.Characters;

namespace Assets.Scripts.Data.Characters.MovementRules.List
{
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Linear")]
    public class LinearMovementRuleData : MovementRuleData
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpHeight;

        public override void Move(Character character, bool jump)
        {
            var physic = character.Body;

            var speed = physic.Force.x;
            speed += _acceleration * Time.deltaTime;
            speed = Mathf.Min(speed, _maxSpeed);
            physic.Force = new Vector2(speed, physic.Force.y);

            if (physic.IsGrounded && jump)
            {
                physic.Force += new Vector2(0,
                    Mathf.Sqrt(2 * _jumpHeight));
            }
        }
    }

}
