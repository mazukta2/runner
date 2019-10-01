using UnityEngine;
using System.Collections;

namespace Game
{
    // Camera following a character
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private CharacterControllerProvider _Provider;

        protected void LateUpdate()
        {
            if (!_Provider.Controller) return;

            transform.position = new Vector3(
                _Provider.Controller.Model.transform.position.x,
                transform.position.y);
        }
    }

}
