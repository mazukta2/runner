using Assets.Scripts.Data.Characters;
using Assets.Scripts.Data.World;
using Assets.Scripts.Game.Scenes.Types;
using Assets.Scripts.Game.Services;

namespace Assets.Scripts.Models.Services
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
            _loading.LoadScene(new LevelSceneData.Loader(SelectedWorldData.Scene, this));
        }
    }
}
