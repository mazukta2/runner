using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Characters/Character")]
    public class CharacterData : ScriptableObject
    {
        public CharacterView ViewPrefab => _viewPrefab;

        [SerializeField] CharacterView _viewPrefab;
    }

}
