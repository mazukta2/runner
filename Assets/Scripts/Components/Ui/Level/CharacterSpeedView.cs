using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Characters.Settings;

namespace Assets.Scripts.Components.Ui.Level
{
    // Just shows character speed.
    public class CharacterSpeedView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private CharacterProvider.Field _characterProvider;

        private void Update()
        {
            _text.text = string.Format("Speed: {0:0.0} ",
                _characterProvider.Get().Body.Force.x);
        }
    }
}

