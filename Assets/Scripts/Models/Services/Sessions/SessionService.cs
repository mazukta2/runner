using Assets.Scripts.Data.Characters;
using Assets.Scripts.Data.World;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Models.Services.Characters;
using Assets.Scripts.Models.Services.Scenes;
using Assets.Scripts.Models.Services.Updater;

namespace Assets.Scripts.Models.Services.Sessions
{
    public class SessionService : IService
    {
        public Character MainCharacter { get; private set; }

        public WorldData WorldData { get; private set; }

        private GameLoadingService _loading;
        public SessionService(PreSessionService preSessionService, CharactersSettingsData settings, GameLoadingService gameLoading, UpdaterService updater)
        {
            WorldData = preSessionService.SelectedWorldData;
            MainCharacter = new Character(preSessionService.SelectedCharacterData,
                new CharacterBody(WorldData.Physics, settings, updater));

            _loading = gameLoading;
        }

        public void FailSession()
        {
            _loading.LoadScene(WorldData.FailScene,
                (services, scene) => { });
        }
    }
}
