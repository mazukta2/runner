using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LoaderSystem : MonoBehaviourSystem<LoaderData, LoaderSystem>
    {
        private bool _isLoading;

        internal void LoadMainMenu()
        {
            StartCoroutine(LoadSceneCoroutine(Data.MainMenu));
        }

        private IEnumerator LoadSceneCoroutine(SceneData scene)
        {
            if (_isLoading)
                throw new Exception("Try to load sceen, while previous is not loaded yet.");

            try
            {
                _isLoading = true;

                yield return StartCoroutine(ClearAll());

                var asyncOperation = scene.LoadAsync();
                if (asyncOperation != null)
                {
                    while (!asyncOperation.isDone)
                        yield return new WaitForEndOfFrame();
                }
            }
            finally
            {
                _isLoading = false;
            }
        }

        private IEnumerator ClearAll()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneByBuildIndex(i);
                // Init scene is always runs
                if (Data.InitScene.IsScene(scene))
                    continue;

                var asyncOperation = SceneManager.UnloadSceneAsync(i);
                while (!asyncOperation.isDone)
                    yield return new WaitForEndOfFrame();
            }
        }

    }

}
