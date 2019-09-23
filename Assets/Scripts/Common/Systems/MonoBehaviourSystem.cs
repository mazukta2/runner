using UnityEngine;
using System.Collections;

namespace Game
{
    public class MonoBehaviourSystem<TData, TBehaviour> : MonoBehaviour
        where TData : MonoBehaviourSystemData<TData, TBehaviour>
        where TBehaviour : MonoBehaviourSystem<TData, TBehaviour>
    {
        protected TData Data { get; private set; }

        public void Init(TData data)
        {
            Data = data;
        }
    }
}

