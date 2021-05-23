using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Physics.Services;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Characters.Services
{
    public class Character
    {
        public CharacterData Data { get; private set; }
        public CharacterPhysic Body { get; private set; }
        public CharacterHitable Hitable { get; private set; }

        public Character(CharacterData characterData,
            CharacterPhysic physic)
        {
            Data = characterData;
            Body = physic;
            Hitable = new CharacterHitable(characterData, physic);
        }
    }
}
