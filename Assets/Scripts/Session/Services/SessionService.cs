using Assets.Scripts.Characters.Services;
using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Game.Loader;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Game.Updater;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Session.PreSession
{
    public class SessionService : IService
    {
        public Character MainCharacter { get; private set; }

        public WorldData WorldData { get; private set; }

        private GameLoadingService _loading;
        public SessionService(PreSessionService preSessionService, GameLoadingService gameLoading, UpdaterService updater)
        {
            WorldData = preSessionService.SelectedWorldData;
            MainCharacter = new Character(preSessionService.SelectedCharacterData, 
                new Physics.Services.CharacterPhysic(WorldData.Physics, updater));

            _loading = gameLoading;
        }

        public void FailSession()
        {
            _loading.LoadScene(WorldData.FailScene,
                (services, scene) => { });
        }
    }
}
