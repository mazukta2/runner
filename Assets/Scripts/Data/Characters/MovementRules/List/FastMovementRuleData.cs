using UnityEngine;
using Assets.Scripts.Models.Entities;

namespace Assets.Scripts.Data.Characters.MovementRules.List
{
    // movement with rapid acceleration after reaching half speed.
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Fast")]
    public class FastMovementRuleData : MovementRuleData
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _jumpHeight;

        public override void Move(Character character, bool jump)
        {
            var speed = character.Force.x;
            if (speed < _maxSpeed / 2)
                speed += _acceleration * Time.deltaTime;
            else
                speed = Mathf.MoveTowards(speed,
                    Mathf.Pow(speed, 2), Time.deltaTime);

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
