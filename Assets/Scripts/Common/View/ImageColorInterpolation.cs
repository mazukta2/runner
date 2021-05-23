using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ImageColorInterpolation : MonoBehaviour
    {
        [SerializeField] private Color _Color1;
        [SerializeField] private Color _Color2;

        [SerializeField] private float _Value;

        private SpriteRenderer _image;

        private void Start()
        {
            _image = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _image.color = Color.Lerp(_Color1, _Color2, _Value);
        }
    }
}

