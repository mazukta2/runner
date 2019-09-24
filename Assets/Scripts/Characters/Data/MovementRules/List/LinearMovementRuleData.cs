using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Movement/Linear")]
    public class LinearMovementRuleData : MovementRuleData
    {
        public override void UpdatePosition(CharacterView view)
        {
            view.transform.position += new Vector3(1 * Time.deltaTime, 0);
        }
    }

}
