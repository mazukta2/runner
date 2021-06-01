using Assets.Scripts.Data.Characters;
using Assets.Scripts.Data.World;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Models.Entities;

namespace Assets.Scripts.Models.Services
{
    public class SessionService : IService
    {
        public Character MainCharacter { get; private set; }
        public WorldData WorldData { get; private set; }

        private GameLoadingService _loading;
        public SessionService(PreSessionService preSessionService, 
            CharactersSettingsData settings, GameLoadingService gameLoading)
        {
            WorldData = preSessionService.SelectedWorldData;
            MainCharacter = new Character(preSessionService.SelectedCharacterData);

            _loading = gameLoading;
        }

        public void FailSession()
        {
            _loading.LoadScene(WorldData.FailScene,
                (services, scene) => { });
        }
    }
}
