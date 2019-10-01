using UnityEngine;
using System.Collections;

namespace Game
{
    // Provide access to a specific character controller. 
    // It's designed to keep an object visibility inside of a small area (scene, prefab)
    // and at same time have an easy and flexible access to this object 
    public class CharacterControllerProvider : Provider
    {
        public GameCharacterController Controller { get; set; }
    }
}
