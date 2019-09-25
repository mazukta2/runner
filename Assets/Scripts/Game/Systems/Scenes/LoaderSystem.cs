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

        internal void LoadLevel(SceneData level)
        {
            StartCoroutine(LoadSceneCoroutine(level));
        }

        private IEnumerator LoadSceneCoroutine(SceneData scene)
        {
            if (_isLoading)
                throw new Exception("Try to load sceen, while previous is not loaded yet.");

            try
            {
                _isLoading = true;

                yield return StartCoroutine(ClearAll());

                if (!SceneManager.GetSceneByName(scene.Path).isLoaded)
                {
                    var asyncOperation = SceneManager.LoadSceneAsync(scene.Path, LoadSceneMode.Additive);
                    if (asyncOperation != null)
                    {
                        while (!asyncOperation.isDone)
                            yield return new WaitForEndOfFrame();
                    }
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
                var scene = SceneManager.GetSceneAt(i);
                if (scene == null || !scene.isLoaded)
                    continue;

                // Init scene is always runs
                if (Data.InitScene.IsScene(scene))
                    continue;

                var asyncOperation = SceneManager.UnloadSceneAsync(scene);
                if (asyncOperation != null)
                {
                    while (!asyncOperation.isDone)
                        yield return new WaitForEndOfFrame();

                }
            }
        }
    }

}
