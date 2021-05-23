using Assets.Scripts.Components.Core;
using Assets.Scripts.Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Services.Game
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
