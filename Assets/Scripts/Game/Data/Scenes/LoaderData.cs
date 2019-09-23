using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Common/Loader")]
    public class LoaderData : MonoBehaviourSystemData<LoaderData, LoaderSystem>
    {
        public SceneData InitScene => _initScene;
        public SceneData MainMenu => _mainMenu;

        [SerializeField] SceneData _initScene;
        [SerializeField] SceneData _mainMenu;
    }

}
