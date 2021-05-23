using UnityEngine;
using System.Collections;
using Game;
using System;

namespace Game
{
    public class GameObjectHidder : MonoBehaviour
    {
        [SerializeField] private GameObject _View;

        public void Show(bool value)
        {
            _View.SetActive(value);
        }
    }

}
