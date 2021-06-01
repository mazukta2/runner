using Assets.Scripts.Data.Characters;
using Assets.Scripts.Game.Services;

namespace Assets.Scripts.Models.Services
{
    public class FailDetectorService : IService
    {
        private SessionService _session;
        private UpdaterService _updater;
        private CharactersSettingsData _charactersSettings;
        private CharacterPhysicsService _physicsService;
        private bool _isCollided;

        public FailDetectorService(SessionService session, CharacterPhysicsService physicsService,
            CharactersSettingsData charactersSettings, UpdaterService updater)
        {
            _session = session;
            _updater = updater;
            _charactersSettings = charactersSettings;
            _physicsService = physicsService;

            _updater.AddUpdater(Update);
        }

        protected void Update()
        {
            if (_physicsService.IsCollidedWith(_session.MainCharacter, _charactersSettings.DangerCollision)
                && !_isCollided)
            {
                _isCollided = true;
                _session.FailSession();
            }
        }
    }
}

