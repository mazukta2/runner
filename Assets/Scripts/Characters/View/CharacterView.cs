using UnityEngine;
using System.Collections;
using Game;
using System;

public class CharacterView : MonoBehaviour
{
    public CharacterData Character => _character;

    [SerializeField] private GameObject _View;

    private CharacterData _character;


    public void Show(bool value)
    {
        _View.SetActive(value);
    }

    internal void Init(CharacterData character)
    {
        _character = character;
    }
}
