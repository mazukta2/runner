using UnityEngine;
using System.Collections;

namespace Game
{
    public class Character : MonoBehaviour
    {
        public CharacterData Data { get => _data; set => _data = value; }
        private CharacterData _data;
    }
}
