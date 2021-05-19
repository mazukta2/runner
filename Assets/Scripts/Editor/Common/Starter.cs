using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityToolbarExtender;


namespace Assets.Scripts.Editor.Common
{
    // this is button to start from main scene. 
    // its my code from another project. sorry for that. its just too convenient. :)
    [InitializeOnLoad]
    public static class Starter
    {
        static Starter()
        {
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
        }

        static void OnPlayModeChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.EnteredEditMode)
            {
                OpenSavedScenes();
            }

            if (!_startedWithRun)
                return;

            if (obj == PlayModeStateChange.ExitingEditMode)
            {
                SaveOpenedScenes();
                OpenMainScene();
            }

            _startedWithRun = false;
        }

        private static bool _startedWithRun;

        static void OnToolbarGUI()
        {
            if (GUI.Button(new Rect(0, 0, 80, 24), new GUIContent(!EditorApplication.isPlaying ? "START ME" : "STOP ME", "Start With Main Scene")))
            {
                if (EditorApplication.isPlaying)
                {
                    Stop();
                }
                else
                {
                    Start();
                }
            }
        }

        public static void Start()
        {
            if (!EditorApplication.isPlaying)
            {
                _startedWithRun = true;
                EditorApplication.isPlaying = true;
            }
        }

        public static void Stop()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
        }

        private static void OpenMainScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");
        }

        private static void SaveOpenedScenes()
        {
            var openedScenes = new List<string>();
            for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
            {
                var scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
                openedScenes.Add(scene.path);
            }
            EditorPrefs.SetString("LastOpenedScenes", string.Join(",", openedScenes));

            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            if (prefabStage != null)
            {
                EditorPrefs.SetString("LastOpenedPrefab", prefabStage.prefabAssetPath);
            }
        }

        private static void OpenSavedScenes()
        {
            var strs = EditorPrefs.GetString("LastOpenedScenes", "");
            var openedScenes = strs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < openedScenes.Length; i++)
            {

                EditorSceneManager.OpenScene(openedScenes[i], i == 0 ? OpenSceneMode.Single : OpenSceneMode.Additive);
            }

            EditorPrefs.SetString("LastOpenedScenes", "");

            var prefabs = EditorPrefs.GetString("LastOpenedPrefab", "");
            var openedPrefabs = prefabs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string openedPrefab in openedPrefabs)
            {
                var mainAsset = AssetDatabase.LoadMainAssetAtPath(openedPrefab);
                AssetDatabase.OpenAsset(mainAsset);
            }

            EditorPrefs.SetString("LastOpenedPrefab", "");
        }
    }
}