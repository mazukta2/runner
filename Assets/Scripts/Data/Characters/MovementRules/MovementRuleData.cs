using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using Assets.Scripts.Models.Services.Characters;
using Assets.Scripts.Models.Entities;

namespace Assets.Scripts.Data.Characters.MovementRules
{
    // character rules for movement
    public abstract class MovementRuleData : ScriptableObject
    {
        // TODO: if moving become more complex this interface will
        // explode. it will be better if moving rules return 
        // class instead.
        public abstract void Move(Character character, bool jump);
    }

}
