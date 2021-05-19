using UnityEngine;
using System.Collections;
using Assets.Scripts.Game;

namespace Game
{
    // Provide an access to global entities of the game. 
    public abstract class ScriptableObjectSingletonData<T> : ScriptableObject
    {
        public virtual T Instance => default(T);

        public abstract T CreateInstance(GameCore gameController);
    }

}
