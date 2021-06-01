using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Components.Providers.Common;
using Assets.Scripts.Models.Services;
using System;

namespace Assets.Scripts.Components.Providers.Sessions
{
    // session provider
    public class SessionProvider : SingleServiceMonoBehaviourProvider<SessionService>
    {
        [Serializable]
        public class Field : ProviderField<SessionProvider, SessionService>
        {
            protected override SessionService GetService(SessionProvider provider)
                => provider.Get();
        }
    }
}