using Assets.Scripts.Components.Core;
using Assets.Scripts.Game.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models.Services.Updater
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
