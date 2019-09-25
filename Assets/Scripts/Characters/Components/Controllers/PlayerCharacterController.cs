using UnityEngine;
using System.Collections;

namespace Game
{
    public class PlayerCharacterController : MonoBehaviour
    {
        public Character Character { get => _Character; set => _Character = value; }
        [SerializeField] public Character _Character;
    }
}
