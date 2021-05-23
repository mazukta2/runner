using Assets.Scripts.Game.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Updater
{
    public class UpdaterService : IService
    {
        private GameCore _core;

        public UpdaterService(GameCore core)
        {
            _core = core;
        }

        public Coroutine AddUpdater(Action action)
        {
            return _core.StartCoroutine(Updater(action));
        }

        public void RemoveUpdater(Coroutine coroutine)
        {
            _core.StopCoroutine(coroutine);
        }

        private IEnumerator Updater(Action action)
        {
            while (true)
            {
                action();
                yield return null;
            }
        }
    }
}
