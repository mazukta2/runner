using Assets.Scripts.Characters.Settings;
using Assets.Scripts.Components.Providers.Common.Services;
using Assets.Scripts.Data.Characters;

namespace Assets.Scripts.Components.Providers.Characters
{
    // all characters from data
    public class AllCharactersDataListProvider : CharacterDataListProvider
    {
        private ServiceSystemKeeper _serviceProvider = new ServiceSystemKeeper();

        public override CharacterData[] Get()
        {
            return _serviceProvider.GetServices().Get<CharactersSettingsData>().Characters;
        }
    }
}