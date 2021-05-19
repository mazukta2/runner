using UnityEngine;
using System.Collections;
using Assets.Scripts.Game;

namespace Game
{
    public abstract class ProvidersListData<TProvider> : ScriptableObjectSingletonData<ProvidersList<TProvider>>
    {
        public override ProvidersList<TProvider> CreateInstance(GameCore gameController)
        {
            return new ProvidersList<TProvider>();
        }
    }

}
