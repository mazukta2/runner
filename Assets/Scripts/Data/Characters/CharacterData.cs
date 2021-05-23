using Assets.Scripts.Data.Characters.MovementRules;
using UnityEngine;

namespace Assets.Scripts.Data.Characters
{
    // Settings for character
    [CreateAssetMenu(menuName = "Game/Characters/Character")]
    public class CharacterData : ScriptableObject
    {
        // simple view. uses only data to show.
        public GameObject MainMenuView => _mainMenuView;
        // view for level. uses model to show.
        public GameObject LevelView => _levelView;
        // Movement rules for character
        public MovementRuleData Movement => _movement;

        [SerializeField] GameObject _mainMenuView;
        [SerializeField] GameObject _levelView;

        [SerializeField] MovementRuleData _movement;
    }

}
