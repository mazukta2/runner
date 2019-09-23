using UnityEngine;
using System.Collections;

namespace Game
{
    public class MonoBehaviourSystemData<TData, TBehaviour> : ScriptableObjectSingletonData<TBehaviour>
        where TData : MonoBehaviourSystemData<TData, TBehaviour>
        where TBehaviour : MonoBehaviourSystem<TData, TBehaviour> 
    {
        public override TBehaviour CreateInstance(GameCore gameController)
        {
            var type = typeof(TBehaviour);
            var go = new GameObject(type.Name, type);
            go.transform.SetParent(gameController.transform);
            var component = go.GetComponent<TBehaviour>();
            // TODO: maybe there is the way to make it safe. Without conversion
            component.Init((TData)this);
            return component;
        }
    }
}
