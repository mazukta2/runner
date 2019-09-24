using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour
{
    public CharacterView View { get => _View; set => _View = value; }

    [SerializeField] public CharacterView _View;

    private void Update()
    {
        if (_View == null)
            return;

        _View.Character.MovementRule.UpdatePosition(_View);
    }
}
