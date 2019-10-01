using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class LoaderV2 : MonoBehaviour
    {
        private static List<SceneData> _toLoad = new List<SceneData>();
        private static List<SceneData> _toUnload = new List<SceneData>();

        private static List<SceneData> _loaded = new List<SceneData>();

        private static LoaderV2 _loadingProcess;

        public static void LoadScene(SceneData sceneData)
        {
            _toUnload.Remove(sceneData);

            if (!_toLoad.Contains(sceneData) && !_loaded.Contains(sceneData))
                _toLoad.Add(sceneData);

            CreateProcess();
        }

        public static void AddToLoaded(SceneData sceneData)
        {
            if (!_loaded.Contains(sceneData))
                _loaded.Add(sceneData);
        }

        public static void UnloadScene(SceneData sceneData)
        {
            _toLoad.Remove(sceneData);

            if (!_toUnload.Contains(sceneData) && _loaded.Contains(sceneData))
                _toUnload.Add(sceneData);

            CreateProcess();
        }

        public static bool IsLoaded(SceneData sceneData)
        {
            return _loaded.Contains(sceneData);
        }

        public static void UnloadLayer(SceneLayerData layer, SceneData scene)
        {
            foreach (var item in _loaded.Concat(_toLoad).ToList())
            {
                if (item.Layer != layer)
                    continue;

                if (item == scene)
                    continue;

                UnloadScene(item);
            }
        }

        private static void CreateProcess()
        {
            if (_loadingProcess)
                return;

            var loading = new GameObject("Loading Process");
            _loadingProcess = loading.AddComponent<LoaderV2>();
            DontDestroyOnLoad(loading);
        }

        private void Awake()
        {
            StartCoroutine(LoadingProcess());
        }

        private IEnumerator LoadingProcess()
        {
            while (_toLoad.Count > 0 || _toUnload.Count > 0)
            {
                for (int i = 0; i <= _toUnload.Count - 1; i++)
                {
                    var scene = _toUnload[i].GetScene();
                    var asyncOperation = SceneManager.UnloadSceneAsync(scene);
                    if (asyncOperation != null)
                    {
                        while (!asyncOperation.isDone)
                            yield return new WaitForEndOfFrame();

                    }
                    _loaded.Remove(_toUnload[i]);
                    _toUnload.Remove(_toUnload[i]);
                    i--;
                }

                for (int i = 0; i <= _toLoad.Count - 1; i++)
                {
                    var asyncOperation = SceneManager.LoadSceneAsync(_toLoad[i].Path, 
                        LoadSceneMode.Additive);
                    if (asyncOperation != null)
                    {
                        while (!asyncOperation.isDone)
                            yield return new WaitForEndOfFrame();
                    }
                    _loaded.Add(_toLoad[i]);
                    _toLoad.Remove(_toLoad[i]);
                    i--;
                }
            }

            Destroy(gameObject);
        }
    }

}
