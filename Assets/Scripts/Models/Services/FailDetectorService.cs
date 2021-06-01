using Assets.Scripts.Game.Services;

namespace Assets.Scripts.Models.Services
{
    public class FailDetectorService : IService
    {
        private SessionService _session;
        private UpdaterService _updater;
        private bool _isCollided;

        public FailDetectorService(SessionService session, UpdaterService updater)
        {
            _session = session;
            _updater = updater;

            _updater.AddUpdater(Update);
        }

        protected void Update()
        {
            //if (_session.MainCharacter.Body.IsCollidingWithDanger() 
            //    && !_isCollided)
            //{
            //    _isCollided = true;
            //    _session.FailSession();
            //}
        }
    }
}

