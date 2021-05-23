using Assets.Scripts.Characters.Components.Views;
using Game;
using UnityEngine;

namespace Assets.Scripts.Characters.Settings
{
    // Describe combination of logic, settings and visual representations for
    // a character. 
    [CreateAssetMenu(menuName = "Game/Characters/Character")]
    public class CharacterData : ScriptableObject
    {
        public GameObject View => _view.gameObject;
        public GameObject Model => _model;
        public MovementRuleData Movement => _movement;
        public ContactFilter2D DangerHiting => _dangerHitter;

        [SerializeField] GameObject _model;
        [SerializeField] GameObject _view;

        [SerializeField] MovementRuleData _movement;

        [SerializeField] ContactFilter2D _dangerHitter;
    }

}
