using UnityEngine;
using Assets.Scripts.Models.Entities;

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
            var speed = character.Force.x;
            speed += _acceleration * Time.deltaTime;
            speed = Mathf.Min(speed, _maxSpeed);
            character.Force = new Vector2(speed, character.Force.y);

            if (character.IsGrounded && jump)
            {
                character.Force += new Vector2(0,
                    Mathf.Sqrt(2 * _jumpHeight));
            }
        }
    }

}
