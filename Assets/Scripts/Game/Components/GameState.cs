using UnityEngine;
using System.Collections;

namespace Game
{
    public class GameState
    {
        public CharacterData Character { get => _CharacterData; set => _CharacterData = value; }
        public WorldData World { get => _WorldData; set => _WorldData = value; }

        private CharacterData _CharacterData;
        private WorldData _WorldData;
    }
}
