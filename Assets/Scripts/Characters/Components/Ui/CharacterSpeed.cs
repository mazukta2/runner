using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    public class CharacterSpeed : MonoBehaviour
    {
        [SerializeField] private Text _Text;
        [SerializeField] private CharacterControllerProvider _Provider;

        private void Update()
        {
            if (!_Provider.Controller)
                return;

            _Text.text = string.Format("Speed: {0:0.0} ", 
                _Provider.Controller.Model.Physics.Force.x);
        }
    }
}

