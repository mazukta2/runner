using UnityEngine;
using System.Collections;

namespace Game
{
    // Convert UI comands to controllers commands
    public class PlayerCharacterController : GameCharacterController
    {
        public CharacterMoveController Mover => _Mover;
        [SerializeField] private CharacterMoveController _Mover;
    }
}
