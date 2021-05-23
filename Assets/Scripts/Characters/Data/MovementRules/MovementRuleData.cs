using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Characters.Services;

namespace Game
{
    public abstract class MovementRuleData : ScriptableObject
    {
        public abstract void Move(Character character, bool jump);
    }

}
