using UnityEngine;
using System.Collections;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters.Services;

namespace Game
{
    // Camera following a character
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private CharacterProvider _characterProvider;
        private Character _character;

        protected void Awake()
        {
            _character = _characterProvider.Get();
        }

        protected void LateUpdate()
        {
            transform.position = new Vector3(_character.Physic.Position.x,
                transform.position.y);
        }
    }

}
