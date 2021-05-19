using Assets.Scripts.Game.Scenes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Loader
{
    public class GameLoading
    {
        private GameCore _core;
        private bool _isLoading;

        public GameLoading(GameCore core)
        {
            _core = core;
        }

        public void LoadScene(SceneInfo sceneData)
        {
            if (_isLoading) throw new Exception("Loading is not completed yet");
            _isLoading = true;
            _core.StartCoroutine(LoadingProcess(sceneData));
        }

        private IEnumerator LoadingProcess(SceneInfo newScene)
        {
            var curentScene = SceneManager.GetActiveScene();
            var unloadingAsyncOperation = SceneManager.UnloadSceneAsync(curentScene);
            if (unloadingAsyncOperation != null)
            {
                while (!unloadingAsyncOperation.isDone)
                    yield return new WaitForEndOfFrame();
            }

            newScene.PreInit(_core.Services);

            var loadingAsyncOperation = SceneManager.LoadSceneAsync(newScene.Path);
            if (loadingAsyncOperation != null)
            {
                while (!loadingAsyncOperation.isDone)
                    yield return new WaitForEndOfFrame();
            }

            _isLoading = false;
        }
    }
}
