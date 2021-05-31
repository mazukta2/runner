using Assets.Scripts.Components.Core;
using Assets.Scripts.Game.Services;

namespace Assets.Scripts.Models.Services
{
    public class GameService : IService
    {
        private GameCore _core;

        public GameService(GameCore core)
        {
            _core = core;
        }

        public void Restart()
        {
            _core.Restart();
        }
    }
}
