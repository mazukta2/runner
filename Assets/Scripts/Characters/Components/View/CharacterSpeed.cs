using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class CharacterSpeed : MonoBehaviour
    {
        public PhysicObject Character { get => _Character; set => _Character = value; }

        [SerializeField] private Text _Text;
        [SerializeField] private PhysicObject _Character;

        private void Update()
        {
            if (!_Character)
                return;

            _Text.text = string.Format("Speed: {0:0.0} ", _Character.Force.x);
        }
    }
}

