using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Game.Loader;
using Assets.Scripts.Game.Services;
using Game;
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
        public WorldData SelectedWorldData { get; private set; }

        private GameLoadingService _loading;

        public PreSessionService(GameLoadingService gameLoading)
        {
            _loading = gameLoading;
        }

        public void SetCharacter(CharacterData characterData)
        {
            SelectedCharacterData = characterData;
        }

        public void SetWorld(WorldData data)
        {
            SelectedWorldData = data;
        }

        public void StartSession()
        {
            _loading.LoadScene(SelectedWorldData.Scene, 
                (services, scene) => scene.Init(services, this));
        }
    }
}
