using UnityEngine;

namespace Assets.Scripts.Components.Common
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteColorInterpolation : MonoBehaviour
    {
        [SerializeField] private Color _color1;
        [SerializeField] private Color _color2;
        [SerializeField] private float _value;

        private SpriteRenderer _image;

        protected void Awake()
        {
            _image = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _image.color = Color.Lerp(_color1, _color2, _value);
        }
    }
}

