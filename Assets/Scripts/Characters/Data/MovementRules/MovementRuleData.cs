using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    public abstract class MovementRuleData : ScriptableObject
    {
        public abstract void UpdatePosition(CharacterView view);
    }

}
