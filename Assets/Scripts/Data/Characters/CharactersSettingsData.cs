using UnityEngine;

namespace Assets.Scripts.Data.Characters
{
    // global setting for all characters
    [CreateAssetMenu(menuName = "Game/Characters/Settings")]
    public class CharactersSettingsData : DataService
    {
        // just list of all characters
        public CharacterData[] Characters => _characters;

        // what is dangerous for characters
        public ContactFilter2D DangerCollision => _dangerCollision;

        [SerializeField] CharacterData[] _characters;
        [SerializeField] ContactFilter2D _dangerCollision;
    }

}
