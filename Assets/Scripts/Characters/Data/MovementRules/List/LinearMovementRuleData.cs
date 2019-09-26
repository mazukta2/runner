﻿using UnityEngine;
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

        public override void UpdatePosition(Character view, bool jumpButton)
        {
            var forceController = view.GetComponent<PhysicObject>();

            //if (forceController.IsGrounded)
            {
                var speed = Mathf.Min(forceController.Force.x + _Acceleration * Time.deltaTime, _MaxSpeed);
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
