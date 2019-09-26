using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Physics/Settings")]
    public class PhysicSettingsData : ScriptableObject
    {
        public Vector2 Friction => _Friction;
        public Vector2 Gravitation => _Gravitation;
        public Vector2 MaximumForce => _MaximumForce;

        [SerializeField] Vector2 _Friction;
        [SerializeField] Vector2 _Gravitation;
        [SerializeField] Vector2 _MaximumForce;
        
    }

}
