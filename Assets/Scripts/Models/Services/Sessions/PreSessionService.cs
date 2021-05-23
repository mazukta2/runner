using Assets.Scripts.Data.Characters;
using Assets.Scripts.Data.World;
using Assets.Scripts.Game.Services;
using Assets.Scripts.Models.Services.Scenes;

namespace Assets.Scripts.Models.Services.Sessions
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
