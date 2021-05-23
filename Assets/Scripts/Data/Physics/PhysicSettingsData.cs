using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Data.Physics
{
    // world physics settings
    [CreateAssetMenu(menuName = "Game/Physics/Settings")]
    public class PhysicSettingsData : ScriptableObject
    {
        public Vector2 Gravitation => _gravitation;
        public ContactFilter2D GroundCollisions => _groudCollisions;

        [SerializeField] Vector2 _gravitation;
        [SerializeField] ContactFilter2D _groudCollisions;

    }

}
