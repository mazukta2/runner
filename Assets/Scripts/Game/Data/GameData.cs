using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Common/Game")]
    public class GameData : ScriptableObjectSingletonData<GameState>
    {
        public override GameState CreateInstance(GameCore gameController)
        {
            return new GameState();
        }
    }

}
