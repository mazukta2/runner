using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Models.Services;
using System;

namespace Assets.Scripts.Components.Providers.Sessions
{
    // prepering for session provider
    public class PreSessionProvider : SingleServiceMonoBehaviourProvider<PreSessionService>
    {
        [Serializable]
        public class Field2 : ProviderField<SingleServiceMonoBehaviourProvider<PreSessionService>, PreSessionProvider>
        {
            protected override PreSessionProvider GetService(SingleServiceMonoBehaviourProvider<PreSessionService> provider)
                => null;
        }
    }
}