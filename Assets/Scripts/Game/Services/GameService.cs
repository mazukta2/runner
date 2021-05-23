using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Services
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
