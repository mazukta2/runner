using UnityEngine;
using System.Collections;

namespace Game
{
    public class SessionProvider : OtherSceneProvider<Session, SessionProvider, SessionProvidersListData>
    {
        [SerializeField] private SessionProvidersListData _ProvidersList;
        protected override ProvidersListData<SessionProvider> Providers => _ProvidersList;

    }
}
