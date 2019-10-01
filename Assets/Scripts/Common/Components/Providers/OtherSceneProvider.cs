using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Game
{
    public abstract class OtherSceneProvider<TInstance, TProvider, TProviderListData> : Provider 
        where TInstance : class
        where TProviderListData : ProvidersListData<TProvider>
        where TProvider : OtherSceneProvider<TInstance, TProvider, TProviderListData>
    {
        public TInstance Instance { get; set; }

        protected abstract ProvidersListData<TProvider> Providers { get; }

        protected void Start()
        {
            Providers.Instance.Reqister((TProvider)this);
        }

        protected void OnDestroy()
        {
            Providers.Instance.UnReqister((TProvider)this);
        }
    }
}

