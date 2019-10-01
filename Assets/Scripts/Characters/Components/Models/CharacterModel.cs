using UnityEngine;
using System.Collections;

namespace Game
{
    // Character model is an gameobject with set of specific animations,
    // physics, colliders etc. Character model must be controlled
    // by another system (player, ai) to do something.
    public class CharacterModel : MonoBehaviour
    {
        public PhysicObject Physics => _Physics;
        [SerializeField] private PhysicObject _Physics;

        public Hitable Hitable => _Hitable;
        [SerializeField] private Hitable _Hitable;
    }
}
