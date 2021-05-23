using Assets.Scripts.Game.Scenes;
using Assets.Scripts.Game.Services;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Loader
{
    public class GameLoadingService : IService
    {
        private GameCore _core;
        private bool _isLoading;

        public GameLoadingService(GameCore core)
        {
            _core = core;
        }

        public void LoadScene<T>(T sceneData, Action<ServicesSystem, T> preInit) where T : SceneInfo
        {
            if (_isLoading) throw new Exception("Loading is not completed yet");
            if (sceneData == null) throw new ArgumentNullException("sceneData is null");
            
            _isLoading = true;
            _core.StartCoroutine(LoadingProcess(sceneData, preInit));
        }

        private IEnumerator LoadingProcess<T>(T newScene, Action<ServicesSystem, T> preInit) where T : SceneInfo
        {
            newScene.PreInit(_core.Services);
            preInit(_core.Services, newScene);

            var loadingAsyncOperation = SceneManager.LoadSceneAsync(newScene.Path);
            if (loadingAsyncOperation != null)
            {
                while (!loadingAsyncOperation.isDone)
                    yield return new WaitForEndOfFrame();
            }

            _isLoading = false;
        }

        internal void LoadScene(object failScene, Func<object, object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
