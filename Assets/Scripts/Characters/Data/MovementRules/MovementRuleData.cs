using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    public abstract class MovementRuleData : ScriptableObject
    {
        public abstract void Move(CharacterController character, bool jump);
    }

}
