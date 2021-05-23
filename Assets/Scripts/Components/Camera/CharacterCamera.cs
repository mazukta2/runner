using UnityEngine;
using Assets.Scripts.Characters.Settings;

namespace Assets.Scripts.Camera.Components
{
    // Camera following a character
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private CharacterProvider.Field _characterProvider;

        protected void LateUpdate()
        {
            transform.position = new Vector3(_characterProvider.Get().Body.Position.x,
                transform.position.y);
        }
    }

}
