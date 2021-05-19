using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Session.PreSession
{
    public class PreSessionService : IService
    {
        public CharacterData SelectedCharacterData { get; private set; }

        public void SetCharacter(CharacterData characterData)
        {
            SelectedCharacterData = characterData;
        }
    }
}
