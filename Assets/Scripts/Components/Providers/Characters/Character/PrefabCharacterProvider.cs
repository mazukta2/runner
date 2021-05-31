using Assets.Scripts.Components.Providers.Characters;
using Assets.Scripts.Models.Entities;
using Assets.Scripts.Models.Services.Characters;

namespace Assets.Scripts.Characters.Settings
{
    // get from spawner
    public class PrefabCharacterProvider : CharacterProvider
    {
        public override Character GetCharacter()
        {
            return transform.GetComponentInParent<ICharacterProxy>().GetCharacter();
        }

        public interface ICharacterProxy
        {
            Character GetCharacter();
        }
    }
}