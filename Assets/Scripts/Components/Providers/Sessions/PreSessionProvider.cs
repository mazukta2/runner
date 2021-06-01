using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Models.Services;
using System;

namespace Assets.Scripts.Components.Providers.Sessions
{
    // prepering for session provider
    public class PreSessionProvider : SingleServiceMonoBehaviourProvider<PreSessionService>
    {
        [Serializable]
        public class Field : ProviderField<PreSessionProvider, PreSessionService>
        {
            protected override PreSessionService GetService(PreSessionProvider provider)
                => provider.Get();
        }
    }
}