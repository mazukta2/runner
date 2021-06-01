using Assets.Scripts.Models.Services;
using System;

namespace Assets.Scripts.Components.Providers.Common
{
    // Main game class provider
    public class GameProvider : SingleServiceMonoBehaviourProvider<GameService>
    {
        [Serializable]
        public class Field : ProviderField<GameProvider, GameService>
        {
            protected override GameService GetService(GameProvider provider)
                => provider.Get();
        }
    }
}