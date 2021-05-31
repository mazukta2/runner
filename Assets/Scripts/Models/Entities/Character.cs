using Assets.Scripts.Data.Characters;
using Assets.Scripts.Models.Services.Characters;

namespace Assets.Scripts.Models.Entities
{
    // character model
    public class Character
    {
        // character settings
        public CharacterData Data { get; private set; }
        // physycal body in world space
        public CharacterBody Body { get; private set; }

        public Character(CharacterData characterData,
            CharacterBody body)
        {
            Data = characterData;
            Body = body;
        }
    }
}
