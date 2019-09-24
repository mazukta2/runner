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

        public override void UpdatePosition(CharacterView view)
        {
            view.transform.position += new Vector3(_MaxSpeed * Time.deltaTime, 0);
        }
    }

}
