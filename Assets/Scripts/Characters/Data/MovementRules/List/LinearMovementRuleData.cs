using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Linear")]
    public class LinearMovementRuleData : MovementRuleData
    {
        [SerializeField] private float _MaxSpeed;
        [SerializeField] private float _JumpForce;

        public override void UpdatePosition(Character view, bool jumpButton)
        {
            var forceController = view.GetComponent<MovementInertion>();
            forceController.SetForceLimit(new Vector2(_MaxSpeed, _MaxSpeed));
            forceController.SetGravitation(1f);

            forceController.AddForce(new Vector2(_MaxSpeed, 0));

            var isGrounded = view.transform.position.y == 0;
            if (isGrounded && jumpButton)
            {
                forceController.AddForce(new Vector2(0, _JumpForce));
            }
        }
    }

}
