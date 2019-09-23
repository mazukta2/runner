using UnityEngine;
using System.Collections;
using Game;

namespace Game
{
    // Provide an access to global entities of the game. 
    public abstract class ScriptableObjectSingletonData<T> : ScriptableObject
    {
        public virtual T Instance => GameCore.Instance.GetDataSingletonInstance<T>(this);

        public abstract T CreateInstance(GameCore gameController);
    }

}
