using UnityEngine;
using System.Collections;

public class CharacterCamera : MonoBehaviour
{
    public GameObject Character { get => _Character; set => _Character = value; }
    [SerializeField] private GameObject _Character;

    private void LateUpdate()
    {
        if (!Character)
            return;

        transform.position = Character.transform.position;
    }
}
