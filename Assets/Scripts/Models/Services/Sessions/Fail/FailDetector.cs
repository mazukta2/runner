using Assets.Scripts.Game.Services;
using Assets.Scripts.Models.Services.Updater;

namespace Assets.Scripts.Models.Services.Sessions.Fail
{
    public class FailDetector : IService
    {
        private bool isCollided;
        private SessionService _session;
        private UpdaterService _updater;

        public FailDetector(SessionService session, UpdaterService updater)
        {
            _session = session;
            _updater = updater;

            _updater.AddUpdater(Update);
        }

        protected void Update()
        {
            if (_session.MainCharacter.Body.IsCollidingWithDanger() 
                && !isCollided)
            {
                isCollided = true;
                _session.FailSession();
            }
        }
    }
}

