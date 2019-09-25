using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour
{
    public GameObject Target { get => _Target; set => _Target = value; }
    [SerializeField] private GameObject _Target;

    private void LateUpdate()
    {
        if (!Target)
            return;

        transform.position = Target.transform.position;
    }
}
