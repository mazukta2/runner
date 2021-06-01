using Assets.Scripts.Components.Core;
using Assets.Scripts.Data.Scenes;
using Assets.Scripts.Game.Services;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Models.Services
{
    public class GameLoadingService : IService
    {
        private GameCore _core;
        private bool _isLoading;

        public GameLoadingService(GameCore core)
        {
            _core = core;
        }

        public void LoadScene<T>(T loader) where T : LoaderBase
        {
            if (_isLoading) throw new Exception("Loading is not completed yet");
            if (loader == null) throw new ArgumentNullException("sceneData is null");

            _isLoading = true;
            _core.StartCoroutine(LoadingProcess(loader));
        }

        private IEnumerator LoadingProcess(LoaderBase loader)
        {
            _core.Services.Clear();
            loader.Load(_core);

            var loadingAsyncOperation = SceneManager.LoadSceneAsync(loader.Path);
            if (loadingAsyncOperation != null)
            {
                while (!loadingAsyncOperation.isDone)
                    yield return new WaitForEndOfFrame();
            }

            _isLoading = false;
        }
    }
}
