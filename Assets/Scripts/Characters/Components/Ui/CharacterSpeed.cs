using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Characters.Services;

namespace Game
{
    public class CharacterSpeed : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private CharacterProvider _characterProvider;
        private Character _character;

        protected void Awake()
        {
            _character = _characterProvider.Get();
        }

        private void Update()
        {
            _text.text = string.Format("Speed: {0:0.0} ",
                _character.Physic.Force.x);
        }
    }
}

