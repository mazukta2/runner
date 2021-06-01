using UnityEngine;
using Assets.Scripts.Characters.Settings;

namespace Assets.Scripts.Components.Camera
{
    // Camera follow a character
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private CharacterProvider.Field _characterProvider;

        protected void LateUpdate()
        {
            transform.position = new Vector3(_characterProvider.Get().Position.x,
                transform.position.y);
        }
    }

}
